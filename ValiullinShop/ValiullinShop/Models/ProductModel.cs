namespace ValiullinShop.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string? Category { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int? Price { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public double? Caliber { get; set; }

        public string? Cartridge { get; set; }

        public int? Clip { get; set; }

        public string? Pneumatics { get; set; }

        public int? Power { get; set; }

        public string? Bullet { get; set; }

        public string? Blade { get; set; }

        public string? Handle { get; set; }

        public double? Lenght { get; set; }

        public int? Range { get; set; }

        public string? Weapon { get; set; }

        public ProductModel(ValiullinShopDB product)
        {
            Id = product.Id;
            Category = product.Category;
            Brand = product.Brand;
            Model = product.Model;
            Price = product.Price;
            Description = product.Description;
            Image = product.Image;
            Caliber = product.Caliber;
            Cartridge=product.Cartridge;
            Clip=product.Clip;
            Power = product.Power;
            Pneumatics=product.Pneumatics;
            Bullet=product.Bullet;
            Blade=product.Blade;
            Handle=product.Handle;
            Lenght=product.Lenght;
            Range=product.Range;
            Weapon=product.Weapon;
        }
        public ProductModel() { }
        public override string ToString()
        {
            return "Артикул" + Id + "Категория" + Category + "Бренд" + Brand + "Modle" + Model + "Цена" + Price + "Описание" + Description + "Картинка" + Image;
        }

    }
}
