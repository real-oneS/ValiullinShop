namespace ValiullinShop.Models.Repository
{
    public class ProductsRepository
    {
        private readonly ValiullinShopDBContext _context;

        public ProductsRepository(ValiullinShopDBContext context)
        {
            _context = context;
        }
        public ProductsRepository()
        {
            _context = new ValiullinShopDBContext();
        }
        public List<ProductModel> GetAll(int? minRan, int? maxRan, double? minLen, double? maxLen, int? power3, int? power7, int? minPrice,int? maxPrice,double? caliber545, double? caliber12, double? caliber308, double? caliber762, 
            int? clip, string sort = null, string search = null, string categoryFire = null, string categoryCold = null, 
            string categoryPnevma = null, string weaponHide = null, string weaponOpen = null, 
            string cartridgeVint = null, string cartridgeVintPul = null, string cartridgeRuj = null, string cartridgePro = null,
            string bladeD2 = null, string bladeXM = null, string bladeAus = null, string blade14 = null,
            string handleStk = null, string handleRez = null, string handleDer = null, string handlePro = null,
            string pnevmaGaz = null, string pnevmaPruj = null, string pnevmaNak = null, string bulletMet = null, string bulletMP = null, string bulletRez = null)
        {
            List<ProductModel> products = new List<ProductModel>();
            using (ValiullinShopDBContext ps = new ValiullinShopDBContext())
            {
                var productsQuery = ps.ValiullinShopDBs.Select(s => new ProductModel()
                {
                    Id = s.Id,
                    Category = s.Category,
                    Brand = s.Brand,
                    Model = s.Model,
                    Price = s.Price,
                    Description = s.Description,
                    Image = s.Image,
                    Caliber = s.Caliber,
                    Cartridge = s.Cartridge,
                    Clip = s.Clip,
                    Power = s.Power,
                    Pneumatics = s.Pneumatics,
                    Bullet = s.Bullet,
                    Blade = s.Blade,
                    Handle = s.Handle,
                    Lenght = s.Lenght,
                    Range = s.Range,
                    Weapon = s.Weapon,
                });
                if (!string.IsNullOrWhiteSpace(search))
                {
                    productsQuery = productsQuery.Where(field => field.Brand.ToLower().Contains(search.ToLower()) || field.Model.ToLower().Contains(search));
                }
                if ((!string.IsNullOrWhiteSpace(categoryFire)) || (!string.IsNullOrWhiteSpace(categoryCold))|| (!string.IsNullOrWhiteSpace(categoryPnevma)))
                {
                    productsQuery = productsQuery.Where(p => p.Category == $"{categoryFire}" || p.Category == $"{categoryCold}" || p.Category == $"{categoryPnevma}");

                }
                if ((!string.IsNullOrWhiteSpace(weaponHide)) || (!string.IsNullOrWhiteSpace(weaponOpen)))
                {
                    productsQuery = productsQuery.Where(p => p.Weapon == $"{weaponHide}" || p.Weapon == $"{weaponOpen}");
                }
                if ((caliber12 != null) || (caliber545 != null) || (caliber308 != null) || (caliber762 != null))
                {
                    productsQuery = productsQuery.Where(p => p.Caliber ==caliber12 || p.Caliber == caliber308 || p.Caliber == caliber545 || p.Caliber == caliber762);
                }
                if ((!string.IsNullOrWhiteSpace(cartridgeVint)) || (!string.IsNullOrWhiteSpace(cartridgeVintPul)) || (!string.IsNullOrWhiteSpace(cartridgeRuj)) || (!string.IsNullOrWhiteSpace(cartridgePro)))
                {
                    productsQuery = productsQuery.Where(p => p.Cartridge == $"{cartridgeVint}" || p.Cartridge == $"{cartridgeVintPul}" || p.Cartridge == $"{cartridgeRuj}" || p.Cartridge == $"{cartridgePro}");
                }
                if ((!string.IsNullOrWhiteSpace(blade14)) || (!string.IsNullOrWhiteSpace(bladeD2)) || (!string.IsNullOrWhiteSpace(bladeXM)) || (!string.IsNullOrWhiteSpace(bladeAus)))
                {
                    productsQuery = productsQuery.Where(p => p.Blade == $"{blade14}" || p.Blade == $"{bladeD2}" || p.Blade == $"{bladeXM}" || p.Blade == $"{bladeAus}");
                }
                if ((!string.IsNullOrWhiteSpace(handleStk)) || (!string.IsNullOrWhiteSpace(handleRez)) || (!string.IsNullOrWhiteSpace(handlePro)) || (!string.IsNullOrWhiteSpace(handleDer)))
                {
                    productsQuery = productsQuery.Where(p => p.Handle == $"{handleStk}" || p.Handle == $"{handleRez}" || p.Handle == $"{handlePro}" || p.Handle == $"{handleDer}");
                }
                if ((!string.IsNullOrWhiteSpace(pnevmaGaz)) || (!string.IsNullOrWhiteSpace(pnevmaPruj)) || (!string.IsNullOrWhiteSpace(pnevmaNak)))
                {
                    productsQuery = productsQuery.Where(p => p.Pneumatics == $"{pnevmaGaz}" || p.Pneumatics == $"{pnevmaPruj}" || p.Pneumatics == $"{pnevmaNak}");
                }
                if ((!string.IsNullOrWhiteSpace(bulletMet)) || (!string.IsNullOrWhiteSpace(bulletMP)) || (!string.IsNullOrWhiteSpace(bulletRez)))
                {
                    productsQuery = productsQuery.Where(p => p.Bullet == $"{bulletMet}" || p.Bullet == $"{bulletMP}" || p.Bullet == $"{bulletRez}");
                }
                if (clip != null)
                {
                    productsQuery = productsQuery.Where(p => p.Clip == clip);
                }
                if (minPrice != null)
                {
                    productsQuery = productsQuery.Where(p => p.Price >= minPrice);
                }
                if (maxPrice!= null)
                {
                    productsQuery = productsQuery.Where(p => p.Price <= maxPrice);
                }
                if (power3 != null)
                {
                    productsQuery = productsQuery.Where(p => p.Power == power3);
                }
                if (power7 != null)
                {
                    productsQuery = productsQuery.Where(p => p.Power == power7);
                }
                if (minLen != null)
                {
                    productsQuery = productsQuery.Where(p => p.Lenght >= minLen);
                }
                if (maxLen != null)
                {
                    productsQuery = productsQuery.Where(p => p.Lenght <= maxLen);
                }
                if (minRan != null)
                {
                    productsQuery = productsQuery.Where(p => p.Range >= minRan);
                }
                if (maxRan != null)
                {
                    productsQuery = productsQuery.Where(p => p.Range <= maxRan);
                }
                if (!string.IsNullOrWhiteSpace(sort))
                    {
                        switch (sort)
                        {
                            case "Name":
                                {
                                    productsQuery = productsQuery.OrderBy(field => field.Brand).ThenBy(field => field.Model);
                                    break;
                                }
                            case "Namedesc":
                                {
                                    productsQuery = productsQuery.OrderByDescending(field => field.Brand).ThenByDescending(field => field.Model);
                                    break;
                                }
                            case "Price":
                                {
                                    productsQuery = productsQuery.OrderBy(field => field.Price);
                                    break;
                                }
                            case "Pricedesc":
                                {
                                    productsQuery = productsQuery.OrderByDescending(field => field.Price);
                                    break;
                                }
                        }
                    }
                    products = productsQuery.ToList();
                }
                return products;
                //var products = _context.ValiullinShopDBs.ToList();
                //return products.Select(product => new ProductModel(product)).ToList();
            }
            public ProductModel FindById(int id)
            {
                var products = _context.ValiullinShopDBs.FirstOrDefault(item => item.Id == id);
                return products != null ? new ProductModel(products) : null;
            }
        }
    }
