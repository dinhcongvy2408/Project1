using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.ViewComponents
{
    public class MenuLoaiViewComponent : ViewComponent
    {
        private readonly HShop2023Context db;
        public MenuLoaiViewComponent(HShop2023Context context) =>db=context;
        public IViewComponentResult Invoke()
        {
            var data = db.Loais.Select(lo => new MenuLoaiVM
            {
                MaLoai=lo.MaLoai,
                TenLoai = lo.TenLoai,
                SoLuong = lo.HangHoas.Count
                
            }).OrderBy(p => p.TenLoai);
            return View(data); //Default.cshtml
        }
    }
}
