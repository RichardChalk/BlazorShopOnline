using Microsoft.EntityFrameworkCore;

namespace ShopOnline.Api.Data
{
    public class BlazorShopOnlineDbContext : DbContext
    {
        public BlazorShopOnlineDbContext(DbContextOptions<BlazorShopOnlineDbContext> options)
            : base(options)
        {

        }
    }
}
