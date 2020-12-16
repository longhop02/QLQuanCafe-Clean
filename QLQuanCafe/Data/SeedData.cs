using System.Collections.Generic;
using System.Linq;
using Infrastructure.Persistent;
using Domain.Entities;

namespace QLQuanCafe.Data
{
    public class SeedData
    {
        public static void InitializeThe(QLQuanCafeContext context){
            context.Database.EnsureCreated();

            if(context.Thes.Any()) return;

            context.Thes.AddRange(new List<The> {
                new The{
                    TenThe = "The 1",
                    TrangThai = "Trong"
                },
                new The{
                    TenThe = "The 2",
                    TrangThai = "Trong"
                },
                new The{
                    TenThe = "The 3",
                    TrangThai = "Trong"
                }
            });

            context.SaveChanges();
        }
        public static void InitializeNUT(QLQuanCafeContext context){
            context.Database.EnsureCreated();

            if(context.DSNU.Any()) return;

            context.DSNU.AddRange(new List<NuocUongThe> {
                
            });

            context.SaveChanges();
        }
        public static void InitializeNU(QLQuanCafeContext context){
            context.Database.EnsureCreated();

            if(context.NUs.Any()) return;

            context.NUs.AddRange(new List<NuocUong> {
                new NuocUong{
                    TenNU = "Tra chanh",
                    DonGia = 10000
                },
                new NuocUong{
                    TenNU = "Tra dao",
                    DonGia = 12000
                },
                new NuocUong{
                    TenNU = "Cafe",
                    DonGia = 15000
                }
            });

            context.SaveChanges();
        }
    }
}