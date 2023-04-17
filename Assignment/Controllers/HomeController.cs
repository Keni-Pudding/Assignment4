using System.Collections.Immutable;
using System.Diagnostics;
using System.Xml.Linq;
using Assignment.IServices;
using Assignment.Models;
using Assignment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

using static Assignment.Services.SessionService;

namespace Assignment.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IProductService productService;
		private readonly ICartDetailService cartDetailService;
		private readonly ICategoryService categoryService;
		private readonly IColorService colorService;
		private readonly ISizeService sizeService;
		private readonly ISupplierService supplierService;
		private readonly IUserService userService;
		private readonly ICartService cartService;
		private readonly IBillDetailService billDetailService;
		private readonly IBillService billService;
		private readonly AssDbContext context;
		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
			productService = new ProductService();
			categoryService = new CategoryService();
			supplierService = new SupplierService();
			sizeService = new SizeService();
			colorService = new ColorService();
			userService = new UserService();
			cartDetailService = new CartDetailService();
			cartService = new CartService();
			billDetailService = new BillDetailService();
			billService = new BillService();
			context = new AssDbContext();

		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Create()
		{
			List<Color> color = colorService.GetAllColor();
			List<Size> size = sizeService.GetAllSize();
			List<Category> categories = categoryService.GetAllCategory();
			List<Supplier> suppliers = supplierService.GetAllSupplier();
			ViewBag.color = color;
			ViewBag.size = size;
			ViewBag.category = categories;
			ViewBag.supplier = suppliers;
			return View();
		}
		[HttpPost]
		public IActionResult Create(Product product, [Bind] IFormFile imageFile)
		{
			//var x = imageFile.FileName;
			if (imageFile != null && imageFile.Length > 0) //không null và không trống
			{
				//Trỏ tới thư mục wwroot để lát nữa thực hiện việc Copy sang
				var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);
				using (var stream = new FileStream(path, FileMode.Create))
				{
					//thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
					imageFile.CopyTo(stream);
				}
				//Gán lại giá trị cho desciption của đối tượng bằng tên file ảnh đã được sao chép
				product.Image = imageFile.FileName;
			}
			if (productService.CreateProdcut(product)) //Nếu thêm thành công
			{
				return RedirectToAction("Product");

			}
			return View();
		}
		public IActionResult Details(Guid ID)
		{
			List<Color> color = colorService.GetAllColor();
			List<Size> size = sizeService.GetAllSize();
			List<Category> categories = categoryService.GetAllCategory();
			List<Supplier> suppliers = supplierService.GetAllSupplier();
			ViewBag.color = color;
			ViewBag.size = size;
			ViewBag.catagory = categories;
			ViewBag.supllier = suppliers;

			AssDbContext context = new AssDbContext();
			var product = context.Products.Find(ID);
			return View(product);
		}
		public IActionResult LogOut()
		{
			HttpContext.Session.Remove("dangnhap");
			return RedirectToAction("Login");
		}
		public IActionResult Privacy()
		{
			return View();
		}


		public IActionResult Login()
		{

			return View();
		}
		[HttpPost]
		public IActionResult Login(string user, string password)
		{
			User LoggedInUser = userService.GetAllUsers().Where(p => p.Username == user && p.Password == password).FirstOrDefault();
			HttpContext.Session.SetString("dangnhap", JsonConvert.SerializeObject(LoggedInUser));
			if (LoggedInUser != null)
			{
				return RedirectToAction("Index");
			}
			return View();
		}


		public IActionResult Bill()
		{
			List<BillDetail> billDetails = billDetailService.GetAllBillDetail();
			List<Bill> bills = context.Bills.Include("User").Include("BillDetails").OrderByDescending(x => x.CreateDate).ToList();
			ViewBag.BillDetail = billDetails;
			ViewBag.Bill = bills;
			return View();

		}

		[HttpPost]

		public IActionResult BillPay()
		{
			string user = HttpContext.Session.GetString("dangnhap");

			if (user == null)
			{
				return RedirectToAction("Login");
			}
			User LoggedInUser = JsonConvert.DeserializeObject<User>(user);
			var _list = cartDetailService.GetAllCartDetail().Where(p => p.UserID == LoggedInUser.ID);
			if (_list.Count() == 0)
			{
				return RedirectToAction("Product");

			}
			else
			{
				Guid id = Guid.NewGuid();
				Bill bill = new Bill()
				{
					ID = id,
					CreateDate = DateTime.Now,
					UserId = LoggedInUser.ID,
					Status = 1,
				};
				billService.CreateBill(bill);
				var listCartDetail = cartDetailService.GetAllCartDetail().Where(p => p.UserID == LoggedInUser.ID).ToList();
				for (int i = 0; i < listCartDetail.Count(); i++)
				{
					var Product = productService.GetProductById(listCartDetail[i].ProductId);
					var cartDetail = cartDetailService.GetAllCartDetail().FirstOrDefault(p => p.ProductId == Product.ID && p.UserID == LoggedInUser.ID);
					BillDetail billDetail = new BillDetail();
					billDetail.ID = Guid.NewGuid();
					billDetail.IDHD = id;
					billDetail.IDSP = Product.ID;
					billDetail.Quantily = cartDetail.Quantity;
					billDetail.Price = cartDetail.Quantity * Product.Price;
					billDetailService.CreateBillDetail(billDetail);

					Product.AvailableQuanlity = Product.AvailableQuanlity - cartDetail.Quantity;
					productService.UpdateProduct(Product);
					//Xóa ở CartDetail
					cartDetailService.DeleteCartDetail(cartDetail.ID);

				};
				return RedirectToAction("Bill");
			}

		}


		public IActionResult BillDetail(Guid IdBilll)
		{
			List<BillDetail> billDetails = context.BillDetails.Include("Products").Where(p => p.IDHD == IdBilll).ToList();
			ViewBag.BillDetails = billDetails;

			List<Product> products = context.Products.Include("Size").Include("Color").Include("Category").ToList();
			ViewBag.Products = products;
			return View();
		}


		public IActionResult ShowCart()
		{

			string user = HttpContext.Session.GetString("dangnhap");
			User LoggedInUser = JsonConvert.DeserializeObject<User>(user);
			List<CartDetail> cartDetails = cartDetailService.GetAllCartDetail().Where(x => x.UserID == LoggedInUser.ID).ToList();
			ViewBag.User = cartDetails;
			var thuoctinh = from a in cartDetailService.GetAllCartDetail().Where(x => x.UserID == LoggedInUser.ID)
							join b in productService.GetAllProduct() on a.ProductId equals b.ID
							join c in colorService.GetAllColor() on b.ColorId equals c.ID
							join d in sizeService.GetAllSize() on b.SizeId equals d.Id
							join e in categoryService.GetAllCategory() on b.CatagoryId equals e.Id
							select new
							{
								name = b.Name,
								color = c.NameColor,
								size = d.NameSize,
								category = e.Name,
								soluong = a.Quantity,
								price = b.Price
							};
			ViewBag.thuoctinh = thuoctinh;
			return View();
		}

		[HttpPost]
		public IActionResult ShowCart(Guid ProductId)
		{
			string user = HttpContext.Session.GetString("dangnhap");
			User LoggedInUser = JsonConvert.DeserializeObject<User>(user);
			List<CartDetail> cartDetails = cartDetailService.GetAllCartDetail().Where(x => x.UserID == LoggedInUser.ID && x.ProductId == ProductId).ToList();

			// List<Cart> Carts =_cartService.GetAllCarts().Where(x => x.UserId == users.Id).ToList();
			if (cartDetails.Count == 0)
			{
				CartDetail cartDetail = new CartDetail()
				{
					ID = Guid.NewGuid(),
					UserID = LoggedInUser.ID,
					ProductId = ProductId,
					Quantity = 1,
				};
				cartDetailService.CreateCartDetail(cartDetail);

			}
			else
			{
				CartDetail cartDetail = new CartDetail();
				cartDetail = cartDetailService.GetAllCartDetail().FirstOrDefault(x => x.UserID == LoggedInUser.ID && x.ProductId == ProductId);
				cartDetail.Quantity = cartDetail.Quantity + 1;
				cartDetailService.UpdateCartDetail(cartDetail);

			}
			return RedirectToAction("ShowCart");
			//return View();
		}



		public IActionResult Delete(Guid id)
		{
			if (productService.DeleteProduct(id))
			{
				return RedirectToAction("Product");
			}
			else return View("Index");
		}

		[HttpGet]
		public IActionResult Edit(Guid Id)
		{
			List<Category> categories = categoryService.GetAllCategory();
			List<Supplier> suppliers = supplierService.GetAllSupplier();
			List<Color> color = colorService.GetAllColor();
			List<Size> size = sizeService.GetAllSize();
			ViewBag.category = categories;
			ViewBag.supplier = suppliers;
			ViewBag.color = color;
			ViewBag.size = size;
			Product p = productService.GetProductById(Id);
			return View(p);
		}
		public IActionResult Edit(Product p, [Bind] IFormFile imageFile)
		{
			//var x = imageFile.FileName;
			if (imageFile != null && imageFile.Length > 0) //không null và không trống
			{
				//Trỏ tới thư mục wwroot để lát nữa thực hiện việc Copy sang
				var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);
				using (var stream = new FileStream(path, FileMode.Create))
				{
					//thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
					imageFile.CopyTo(stream);
				}
				//Gán lại giá trị cho desciption của đối tượng bằng tên file ảnh đã được sao chép
				p.Image = imageFile.FileName;
			}
			if (productService.UpdateProduct(p)) //Nếu thêm thành công
			{
				return RedirectToAction("Product");

			}
			return View();
		}
	
		public IActionResult Product()
		{
			List<Product> products = productService.GetAllProduct();
			ViewBag.Product = products;
			return View(products);
		}
		public IActionResult Manage()
		{
			List<Product> products = productService.GetAllProduct();
			ViewBag.Product = products;
			return View(products);

		}

	
		public IActionResult EditBill(Guid id)
		{
			Bill b = billService.GetBillById(id);
			return View(b);
		}
		[HttpPost]
		public IActionResult EditBill(Bill b)
		{
			if (billService.UpdateBill(b))
			{
				return RedirectToAction("Bill");
			}
			else
			{ return BadRequest(); }
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}



