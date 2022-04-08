using M01.Models;

namespace M01.Services
{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductModel[] {
                new ProductModel() {Id =1, Name="phone1", Price=123},
                new ProductModel() {Id =2, Name="phone2", Price=126},
                new ProductModel() {Id =3, Name="phone3", Price=125},
                new ProductModel() {Id =4, Name="phone4", Price=124}
            });
        }
    }
}