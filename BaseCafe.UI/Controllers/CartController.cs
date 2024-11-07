using BaseCafe.BLL.DTOs;
using BaseCafe.BLL.Managers.Abstract;
using BaseCafe.DAL.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BaseCafe.UI.Controllers
{
    public class CartController : Controller
    {
        //Card alınarak ürnün bilgileir kategoris olucak sonrasında eltında SepeteEkle buttonu olucak bunu indexe yapacağız menu tasarlayalım 
        private readonly IGenericManager<ProductDTO, Product> _productManager;
        private readonly IGenericManager<CategoryDTO, Category> _categoryManager;
        private readonly IGenericManager<OrderDTO, Order> _orderManager;
        private readonly IGenericManager<OrderDetailDTO, OrderDetail> _orderDetailManager;
        public CartController(IGenericManager<ProductDTO, Product> productManager, IGenericManager<CategoryDTO, Category> categoryManager, IGenericManager<OrderDTO, Order> orderManager, IGenericManager<OrderDetailDTO, OrderDetail> orderDetailManager)
        {
            _categoryManager= categoryManager;
            _productManager= productManager;
            _orderManager = orderManager;
            _orderDetailManager=orderDetailManager;
        }
        public IActionResult Index()
        {
            var prodcuts = _productManager.GetAll();
            var productDtos = prodcuts.Select(
                p => new
                {
                    p.Id,
                    p.CategoryID,
                    p.Name,
                    p.Price,
                    p.Description,
                    p.StockQuantity,
                    categoryName = _categoryManager.Find(p.CategoryID)?.Name
                }
                ).ToList();
            return View(productDtos);
        }
        public IActionResult Cart()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CompleteOrder([FromBody]List<CartDTO> cart)
        {
            if (cart == null || !cart.Any())
            {
                return BadRequest("Cart is null");
            }

            //sepetteki toplam tutar
            var totalAmount = cart.Sum(item => item.Quantity*_productManager.Find(item.ProductID).Price);

            //yeni sipariş oluştur
            var newOrder = new OrderDTO(0, DateTime.Now, totalAmount, "Created");

            //sipariş ekle

            var createdOrder = _orderManager.Add(newOrder);

            //cookieden OrderIDyi Tutma 
            Response.Cookies.Append("OrderID",createdOrder.Id.ToString());

            foreach (var item in cart)
            {
                //sipariş dettayları oluştur
                var orderDetail = new OrderDetailDTO(0, createdOrder.Id, item.ProductID, item.Quantity, _productManager.Find(item.ProductID).Price);

                //sipariş detaylarını ekle
                _orderDetailManager.Add(orderDetail);
            }

            return Ok("Order Success");

        }
    }
}
