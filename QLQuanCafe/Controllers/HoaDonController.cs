using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System;

namespace QLQuanCafe.Controllers
{
    public class HoaDonController : Controller
    {
        private readonly INURepository nuRepository;
        private readonly IHoaDonRepository hoadonRepository;
        private readonly ICTHDRepository cthdRepository;

        public HoaDonController(INURepository nuRepository, IHoaDonRepository hoadonRepository, ICTHDRepository cthdRepository){
            this.nuRepository = nuRepository;
            this.hoadonRepository = hoadonRepository;
            this.cthdRepository = cthdRepository;
        }

        public IActionResult Index(){
            var hds = hoadonRepository.GetAll();
            ViewBag.hds = hds;
            return View();
        }

        [HttpGet]
        public IActionResult ChiTietHoaDon(int idHD){
            HoaDon hd = new HoaDon();
            hd = hoadonRepository.GetBy(idHD);
            var nus = nuRepository.GetAll();
            var cthds = cthdRepository.GetAll();
            ViewBag.hd = hd;
            ViewBag.nus = nus;
            ViewBag.cthds = cthds;
            return View();
        }

        [HttpPost]
        public string timHoaDon(DateTime ngayTruoc, DateTime ngaySau){
            string code = "";
            var hds = hoadonRepository.GetAll();
            List<HoaDon> hds1 = new List<HoaDon>();
            foreach(var hd in hds){
                if(ngayTruoc==DateTime.MinValue){
                    int result = DateTime.Compare(hd.NgayLap, ngaySau);
                    if(result <= 0){
                        hds1.Add(hd);
                    }
                }
                else if(ngaySau==DateTime.MinValue){
                    int result = DateTime.Compare(hd.NgayLap, ngayTruoc);
                    if(result >= 0){
                        hds1.Add(hd);
                    }
                }else
                {
                    int result1 = DateTime.Compare(hd.NgayLap, ngayTruoc);
                    int result2 = DateTime.Compare(hd.NgayLap, ngaySau);
                    if(result1 >= 0 && result2 <= 0){
                        hds1.Add(hd);
                    }
                }
            }
            code = code + "<table class='table'>";
            code = code + "<thead>";
            code = code + "<tr>";
            code = code + "<th>Tai khoan</th>";
            code = code + "<th>Ngay lap</th>";
            code = code + "<th>Tong tien</th>";
            code = code + "<th>Giam gia</th>";
            code = code + "<th>Thanh tien</th>";
            code = code + "<th>Chi tiet</th>";
            code = code + "</tr>";
            code = code + "</thead>";
            foreach(var hd in hds1){
                code = code + "<tr>";
                code = code + "<td>" + hd.TaiKhoan + "</td>";
                code = code + "<td>" + hd.NgayLap + "</td>";
                code = code + "<td>" + hd.TongTien + "</td>";
                code = code + "<td>" + hd.GiamGia + "</td>";
                code = code + "<td>" + hd.ThanhTien + "</td>";
                code = code + "<td><a asp-asp-controller='HoaDon' asp-action='ChiTietHoaDon' asp-route-idHD='" + hd.Id + "'>Chi tiet</a></td>";
                code = code + "</tr>";
            }
            code = code + "</table>";

            return code;
        }
    }
}