using WebApplication1.EF_Core;

namespace Lpg_Backend.Model
{
    public class DbHelpher
    {
        private EF_DataContext _context;
        public DbHelpher(EF_DataContext context)
        {
            _context = context;
        }

        public List<ProductModel> GetProducts()
        {

            List<ProductModel> response = new List<ProductModel>();
            var dataList = _context.Products.ToList();
            dataList.ForEach(row => response.Add(new ProductModel()
            {
                Id = row.Id,
                Image = row.Image,
                Name = row.Name,
                Description = row.Description,
                Price = row.Price,
                Quantity = row.Quantity,
                Rating = row.Rating,


            }));
            return response;
        }

        public ProductModel GetProduct(int id)
        {
            List<ProductModel> response = new List<ProductModel>();
            var   row = _context.Products.Where(d => d.Id.Equals(id)).FirstOrDefault();
            if (row != null)
            {
                return new ProductModel()
                {
                    Id = row.Id,
                    Image = row.Image,
                    Name = row.Name,
                    Description = row.Description,
                    Price = row.Price,
                    Quantity = row.Quantity,
                    Rating = row.Rating,
                };
            }
            else { return new ProductModel() { Id = -1,Name=null,Image=null,Description=null,Price=0f,Quantity=0,Rating=0 }; }


        }


    }
}
