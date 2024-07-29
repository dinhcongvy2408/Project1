﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly HShop2023Context db;
        public HangHoaController(HShop2023Context context)
        {
            db = context;
        }
        public IActionResult Index(int? loai)
        {
            var hangHoas = db.HangHoas.AsQueryable();
            if(loai.HasValue)
            {
                hangHoas = hangHoas.Where(p=>p.MaLoai == loai.Value);
            }
            var result = hangHoas.Select(p => new HangHoaVM {
                MaHh=p.MaHh,
                TenHH=p.TenHh,
                DonGia=p.DonGia ?? 0,
                Hinh =p.Hinh ??"",
                MoTaNgan=p.MoTaDonVi ?? "",
                TenLoai = p.MaLoaiNavigation.TenLoai

            });
            return View(result);
        }
        public IActionResult Search(string? query)
        {
            var hangHoas = db.HangHoas.AsQueryable();
                 if (query != null)
            {
                hangHoas = hangHoas.Where(p=>p.TenHh.Contains(query));
            }
            var result = hangHoas.Select(p => new HangHoaVM
            {
                MaHh = p.MaHh,
                TenHH = p.TenHh,
                DonGia = p.DonGia ?? 0,
                Hinh = p.Hinh ?? "",
                MoTaNgan = p.MoTaDonVi ?? "",
                TenLoai = p.MaLoaiNavigation.TenLoai
            });
            return View(result);
        }
        public IActionResult Detail(int id)
        {
            var data = db.HangHoas
                .Include(p=>p.MaLoaiNavigation)
                .SingleOrDefault(p=>p.MaHh == id);
            if(data == null)
            {
                TempData["Message"] = $"Không có mã sản phẩm có mã {id}";
                return Redirect("/404");
            }
            var result = new ChiTietHangHoaVM
            {
                MaHh=data.MaHh,
                TenHH=data.TenHh,
                DonGia=data.DonGia ?? 0,
                ChiTiet=data.MoTa ?? string.Empty,
                Hinh=data.Hinh ?? string.Empty,
                TenLoai=data.MaLoaiNavigation.TenLoai,
                SoLuongTon=10,
                DiemDanhGia=5,
            };
            return View(result);
        }
    }
}
