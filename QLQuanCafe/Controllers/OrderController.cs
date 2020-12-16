using System.Collections.Generic;
using System.Dynamic;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Persistent;
using Domain.Repositories;
using Domain.Entities;
using System;

namespace QLQuanCafe.Controllers
{
    public class OrderController : Controller
    {
        private readonly ITheRepository theRepository;

        private readonly IDSNURepository dsnuRepository;

        private readonly INURepository  nuRepository;

        private readonly IHoaDonRepository hoadonRepository;

        private readonly ICTHDRepository cthdRepository;
        public OrderController(ITheRepository theRepository, IDSNURepository dsnuRepository, INURepository nuRepository, IHoaDonRepository hoadonRepository, ICTHDRepository cthdRepository){
            this.theRepository = theRepository;
            this.dsnuRepository = dsnuRepository;
            this.nuRepository = nuRepository;
            this.hoadonRepository = hoadonRepository;
            this.cthdRepository = cthdRepository;
        }

        public IActionResult Index(){
            var thes = theRepository.GetAll();
            var dsnu = dsnuRepository.GetAll();
            var nus = nuRepository.GetAll();
            List<NuocUongThe> nuts = new List<NuocUongThe>();
            foreach(var nut in dsnu){
                if(nut.IdThe==0){
                    nuts.Add(nut);
                }
            }
            The the1 = new The();
            the1.TenThe="";
            the1.Id=-1;
            the1.TrangThai="";
            ViewBag.thes = thes;
            ViewBag.dsnu = nuts;
            ViewBag.nus = nus;
            ViewBag.the = the1;
            return View();
        }
        
       [HttpPost]
        public IActionResult Index(int idThe){
            var thes = theRepository.GetAll();
            var dsnu = dsnuRepository.GetAll();
            List<NuocUongThe> nuts = new List<NuocUongThe>();
            List<NuocUong> nus1 = new List<NuocUong>();
            foreach(var nut in dsnu){               
                if(nut.IdThe==idThe){
                    nuts.Add(nut);
                }
            }
            The the1 = theRepository.GetBy(idThe);
            var nus = nuRepository.GetAll();
            ViewBag.thes = thes;
            ViewBag.dsnu = nuts;
            ViewBag.nus = nus;
            ViewBag.the = the1;
            return View();
        }
        [HttpPost]
        public int xuLySoLuong(int idNUT, int soLuong){
            NuocUongThe nut = new NuocUongThe();
            nut = dsnuRepository.GetBy(idNUT);
            nut.SoLuong = soLuong;
            NuocUong nu = new NuocUong();
            nu = nuRepository.GetBy(nut.IdNU);
            var tongTien = nu.DonGia*soLuong;
            nut.TongTien = tongTien;
            dsnuRepository.Update(nut);
            return tongTien;
        }
        [HttpPost]
        public string xuLyTrangThai(int idThe, string trangThai){
            string code = "";
            string code1 = "";
            The the = new The();
            the = theRepository.GetBy(idThe);
            if(trangThai == "Trong"){
                var dsnu = dsnuRepository.GetAll();
                var nus = nuRepository.GetAll();
                the.TrangThai = "Nhap nuoc uong";
                code1 = code1 + "<table class='table'>";
                code1 = code1 + "<thead>";
                code1 = code1 + "<tr>";
                code1 = code1 + "<th>Ten nuoc uong</th>";
                code1 = code1 + "<th>Don gia</th>";
                code1 = code1 + "</tr>";
                code1 = code1 + "</thead>";
                foreach(var nu in nus){
                    code1 = code1 + "<tr>";
                    code1 = code1 + "<td>" + nu.TenNU + "</td>";
                    code1 = code1 + "<td>" + nu.DonGia + "</td>";
                    code1 = code1 + "<td>";
                    code1 = code1 + "<input id='them '" + nu.Id + "' type='button' value='Them' onclick='themNuocUong(" + nu.Id + ", " + the.Id + ");'>";
                    code1 = code1 + "</td>";
                    code1 = code1 + "</tr>";
                }
                code1 = code1 + "</table>";
            }
            else if(trangThai == "Nhap nuoc uong"){
                the.TrangThai = "Cho hoan tat";
                var dsnu = dsnuRepository.GetAll();
                var nus = nuRepository.GetAll();
                code = code + "<table class='table'>";
                code = code + "<thead>";
                code = code + "<tr>";
                code = code + "<th>Nuoc uong</th>";
                code = code + "<th>So luong</th>";
                code = code + "<th>Tong tien</th>";
                code =code + "</tr>";
                code = code + "</thead>";
                dsnu = dsnuRepository.GetAll();
                foreach(var nut in dsnu){
                    if(nut.IdThe == idThe){
                        int donGia = 0;
                        code = code + "<tr>";
                        foreach(var nu in nus){
                            if(nut.IdNU == nu.Id){
                                code = code + "<td>" + nu.TenNU + "</td>";
                                donGia = nu.DonGia;
                                break;
                            }
                        }
                        code = code + "<td>";
                        code = code + "<input name='giam' type='button' value='-' onclick='giamSoLuong(" + donGia +", " + nut.Id +")' disabled>";
                        code = code + "<input id='soLuong " + nut.Id + "' type='text' value='" + nut.SoLuong + "' style='text-align: center; width: 30px;' onchange='tongTien(" + donGia +", " + nut.Id +");' disabled>";
                        code = code + "<input name='tang' type='button' value='+' onclick='tangSoLuong(" + donGia +", " + nut.Id +");' disabled>";
                        code = code + "</td>";
                        code = code + "<td id='tongTien " + nut.Id + "'>" + nut.TongTien + "</td>";
                        code = code + "<td><input type='button' value='Xoa' onclick='xoaNU(" + idThe + ", " + nut.Id + ")' disabled></td>";
                        code = code + "</tr>";
                    }
                }
                code = code + "</table>";

                code1 = code1 + "<table class='table'>";
                code1 = code1 + "<thead>";
                code1 = code1 + "<tr>";
                code1 = code1 + "<th>Ten nuoc uong</th>";
                code1 = code1 + "<th>Don gia</th>";
                code1 = code1 + "</tr>";
                code1 = code1 + "</thead>";
                foreach(var nu in nus){
                    code1 = code1 + "<tr>";
                    code1 = code1 + "<td>" + nu.TenNU + "</td>";
                    code1 = code1 + "<td>" + nu.DonGia + "</td>";
                    code1 = code1 + "<td>";
                    code1 = code1 + "<input id='them '" + nu.Id + "' type='button' value='Them' onclick='themNuocUong(" + nu.Id + ", " + the.Id + ")' disabled>";
                    code1 = code1 + "</td>";
                    code1 = code1 + "</tr>";
                }
                code1 = code1 + "</table>";
            }
            else if(trangThai == "Cho hoan tat"){
                the.TrangThai = "Trong";
            }else if(trangThai == "Huy"){
                the.TrangThai = "Trong";
                var dsnu = dsnuRepository.GetAll();
                var nus = nuRepository.GetAll();
                foreach(var nut in dsnu){
                    if(nut.IdThe == idThe){
                        dsnuRepository.Remove(nut);
                    }
                }
                code = code + "<table class='table'>";
                code = code + "<thead>";
                code = code + "<tr>";
                code = code + "<th>Nuoc uong</th>";
                code = code + "<th>So luong</th>";
                code = code + "<th>Tong tien</th>";
                code =code + "</tr>";
                code = code + "</thead>";
                code = code + "</table>";

                code1 = code1 + "<table class='table'>";
                code1 = code1 + "<thead>";
                code1 = code1 + "<tr>";
                code1 = code1 + "<th>Ten nuoc uong</th>";
                code1 = code1 + "<th>Don gia</th>";
                code1 = code1 + "</tr>";
                code1 = code1 + "</thead>";
                foreach(var nu in nus){
                    code1 = code1 + "<tr>";
                    code1 = code1 + "<td>" + nu.TenNU + "</td>";
                    code1 = code1 + "<td>" + nu.DonGia + "</td>";
                    code1 = code1 + "<td>";
                    code1 = code1 + "<input id='them '" + nu.Id + "' type='button' value='Them' onclick='themNuocUong(" + nu.Id + ", " + the.Id + ")' disabled>";
                    code1 = code1 + "</td>";
                    code1 = code1 + "</tr>";
                }
                code1 = code1 + "</table>";
            }
            theRepository.Update(the);
            the = theRepository.GetBy(idThe);
            string result = "";
            result = result + the.TrangThai + "|";
            result = result + code + "|";
            result = result + code1;
            return result;
        }

        [HttpPost]
        public string xuLyThemNuocUong(int idNU, int idThe){          
            string code = "";
            var dsnu = dsnuRepository.GetAll();
            var nus = nuRepository.GetAll();
            int idNUT = 0;
            foreach(var nut in dsnu){
                if(nut.IdNU == idNU && nut.IdThe == idThe){
                    idNUT = nut.Id;
                }
            }
            if(idNUT == 0){
                 var nu = nuRepository.GetBy(idNU); 
                 NuocUongThe nut = new NuocUongThe();
                 nut.IdThe = idThe;
                 nut.IdNU = idNU;
                 nut.SoLuong = 1;
                 nut.TongTien = nu.DonGia;
                dsnuRepository.Add(nut);
            }else{
                var nu = nuRepository.GetBy(idNU); 
                var nut = dsnuRepository.GetBy(idNUT);
                nut.SoLuong = nut.SoLuong + 1;
                nut.TongTien = nu.DonGia*nut.SoLuong;
                dsnuRepository.Update(nut);
            }
            dsnu = dsnuRepository.GetAll();  
            code = code + "<table class='table'>";
            code = code + "<thead>";
            code = code + "<tr>";
            code = code + "<th>Nuoc uong</th>";
            code = code + "<th>So luong</th>";
            code = code + "<th>Tong tien</th>";
            code =code + "</tr>";
            code = code + "</thead>";
            foreach(var nut in dsnu){
                if(nut.IdThe == idThe){
                    int donGia = 0;
                    code = code + "<tr>";
                    foreach(var nu in nus){
                        if(nut.IdNU == nu.Id){
                            code = code + "<td>" + nu.TenNU + "</td>";
                            donGia = nu.DonGia;
                            break;
                        }
                    }
                    code = code + "<td>";
                    code = code + "<input name='giam' type='button' value='-' onclick='giamSoLuong(" + donGia +", " + nut.Id +");'>";
                    code = code + "<input id='soLuong " + nut.Id + "' type='text' value='" + nut.SoLuong + "' style='text-align: center; width: 30px;' onchange='tongTien(" + donGia +", " + nut.Id +");'>";
                    code = code + "<input name='tang' type='button' value='+' onclick='tangSoLuong(" + donGia +", " + nut.Id +");'>";
                    code = code + "</td>";
                    code = code + "<td id='tongTien " + nut.Id + "'>" + nut.TongTien + "</td>";
                    code = code + "<td><input type='button' value='Xoa' onclick='xoaNU(" + idThe + ", " + nut.Id + ")'></td>";
                    code = code + "</tr>";
                }
            }
            code = code + "</table>";
            return code;
        }

        [HttpPost]
        public string xuLyXoaNU(int idThe, int idNUT){
            string code = "";
            NuocUongThe nut = dsnuRepository.GetBy(idNUT);
            dsnuRepository.Remove(nut);
            var dsnu = dsnuRepository.GetAll();
            var nus = nuRepository.GetAll();  
            code = code + "<table class='table'>";
            code = code + "<thead>";
            code = code + "<tr>";
            code = code + "<th>Nuoc uong</th>";
            code = code + "<th>So luong</th>";
            code = code + "<th>Tong tien</th>";
            code =code + "</tr>";
            code = code + "</thead>";
            foreach(var nut1 in dsnu){
                if(nut1.IdThe == idThe){
                    int donGia = 0;
                    code = code + "<tr>";
                    foreach(var nu in nus){
                        if(nut1.IdNU == nu.Id){
                            code = code + "<td>" + nu.TenNU + "</td>";
                            donGia = nu.DonGia;
                            break;
                        }
                    }
                    code = code + "<td>";
                    code = code + "<input name='giam' type='button' value='-' onclick='giamSoLuong(" + donGia +", " + nut1.Id +");'>";
                    code = code + "<input id='soLuong " + nut1.Id + "' type='text' value='" + nut1.SoLuong + "' style='text-align: center; width: 30px;' onchange='tongTien(" + donGia +", " + nut.Id +");'>";
                    code = code + "<input name='tang' type='button' value='+' onclick='tangSoLuong(" + donGia +", " + nut1.Id +");'>";
                    code = code + "</td>";
                    code = code + "<td id='tongTien " + nut1.Id + "'>" + nut1.TongTien + "</td>";
                    code = code + "<td><input type='button' value='Xoa' onclick='xoaNU(" + idThe + ", " + @nut1.Id + ")'></td>";
                    code = code + "</tr>";
                }
            }
            code = code + "</table>";
            return code;
        }

        [HttpPost]
        public int xuLyTongTien(int idThe){
            int tongTien = 0;
            var dsnu = dsnuRepository.GetAll();
            foreach(var nut in dsnu){
                if(nut.IdThe == idThe){
                    tongTien = tongTien + nut.TongTien;
                }
            }
            return tongTien;
        }

        [HttpPost]
        public string taoHoaDon(int idThe, int tongTien, int giamGia, int thanhTien){
            string code = "";
            var dsnu = dsnuRepository.GetAll();
            HoaDon hd = new HoaDon();
            hd.TaiKhoan = User.Identity.Name;
            hd.NgayLap = DateTime.Now;
            hd.TongTien = tongTien;
            hd.GiamGia = giamGia;
            hd.ThanhTien = thanhTien;
            hd.TrangThai = 1;
            hoadonRepository.Add(hd);
            var hds = hoadonRepository.GetAll();
            foreach(var hd1 in hds){
                if(hd1.TrangThai == 1){
                    hd.Id = hd1.Id;
                    hd.TrangThai = 2;
                    hoadonRepository.Update(hd);
                    break;
                }
            }
            foreach(var nut in dsnu){
                if(nut.IdThe == idThe){
                    ChiTietHoaDon cthd = new ChiTietHoaDon();
                    cthd.IdHD = hd.Id;
                    cthd.IdNU = nut.IdNU;
                    cthd.SoLuong = nut.SoLuong;
                    cthd.TongTien = nut.TongTien;
                    cthdRepository.Add(cthd);
                }
            }
            foreach(var nut in dsnu){
                if(nut.IdThe == idThe){
                    dsnuRepository.Remove(nut);
                }
            }
            code = code + "<table class='table'>";
            code = code + "<thead>";
            code = code + "<tr>";
            code = code + "<th>Nuoc uong</th>";
            code = code + "<th>So luong</th>";
            code = code + "<th>Tong tien</th>";
            code =code + "</tr>";
            code = code + "</thead>";
            code = code + "</table>";
            return code;
        }
    }
}