using Microsoft.AspNetCore.Mvc;
using Udemy.Dependency.Services;

namespace Udemy.Dependency.Controllers
{
    public class HomeController : Controller
    {   //constructor içinde yer alan bu değere ulaşabilmem için bir değişken tanımlamam gerek aynı değişkenden.
        private readonly IProductService _productService;

        //services klasörü içinde yer alan ITransient,IScoped,ISingletonları çağıralım.
        private readonly ISingletonServices _singletonServices;
        private readonly IScopedServices _scopedServices;
        private readonly ITransientServices _transientServices;
        public HomeController(IProductService productService, ISingletonServices singletonServices, IScopedServices scopedServices, ITransientServices transientServices)
        {
            _productService = productService;
            _singletonServices = singletonServices;
            _scopedServices = scopedServices;
            _transientServices = transientServices;
        }

        public IActionResult Index()
        {   //dependency inversion olmasaydı biz gettotal() metodunu newleyerek şu şekilde kullanacaktık.
            //ProductManager productManager = new ProductManager();
            //productManager.GetTotal();
            //ancak burada biz bağımlılığımızı arttırmış oluyoruz buna gerek yok.

            //dependency injection ile bunu newlemeden kullanabiliriz. Constructor içinde IProductService tanıt dependency inj. şunu diyecek IProductService gördüğün zaman productmanager örneğini al.
            //bu sayede biz newlemeden ilgili gettotal() metoduna ulaşım sağlıyoruz.


            //viewbag ile gönderelim farkını görelim singleton,scoped ve transient
            ViewBag.Singleton = _singletonServices.GuidId;
            ViewBag.Scoped = _scopedServices.GuidId;
            ViewBag.Transient = _transientServices.GuidId;
            _productService.GetTotal();
            return View();
        }
    }

    public interface IProductService
    {
        int GetTotal();
    }

    public class ProductManager : IProductService
    {
        public int GetTotal()
        {
            return 40;
        }
    }
}
