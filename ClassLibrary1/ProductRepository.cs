﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Commonlayer;
using Commonlayer.Views;
using System.Data.Entity.Infrastructure;

namespace DataAccessLayer
{
    public class ProductRepository : ConnectionClass
    {
        public ProductRepository() : base() { }

        public IQueryable<ProductView> GetProducts()
        {            
            var list = (from p in Entity.Products
                        where p.isActive == true
                        select new ProductView
                        {
                            ProductID = p.ProductID,
                            Name = p.Name,
                            Description = p.Description,
                            CategoryID = p.CategoryID,
                            ImageLink = p.ImageLink,
                            Price = p.Price,
                            Username = p.Username,
                            Stock= p.Stock,
                            isActive = p.isActive
                        }
                    ).Distinct();

           return list.AsQueryable();
        
        }


        public IQueryable<CategoryView> getCategories()
        {
            var list = (from p in Entity.Categories
                        select new CategoryView
                        {
                           CategoryID = p.CategoryID,
                           Name = p.Name,
                           ImageLink = p.ImageLink,
                           ParentID = p.ParentID
                        }
                  ).Distinct();

            return list.AsQueryable();
        }

        public IQueryable<CategoryView> getSubCategories()
        {
            var list = (from p in Entity.SubCategories
                        select new CategoryView
                        {
                            CategoryID = p.SubCategoryID,
                            Name = p.Name,
                            ImageLink = p.ImageLink,
                            ParentID = p.ParentCategoryID
                        }
                  ).Distinct();

            return
                
                list.AsQueryable();
        }

        public String getSubCategoryofProduct(int ProductID)
        {
            return (from p in Entity.Products
                    join ps in Entity.Categories
                    on p.CategoryID equals ps.CategoryID
                    where (p.ProductID == ProductID) && (ps.ParentID!=null)
                    select ps.Name).SingleOrDefault();
        }

        public IQueryable<CategoryView> getMainCategories()
        {
            var list = (from p in Entity.Categories
                        where (p.SubCategories == null)
                        select new CategoryView
                        {
                            CategoryID = p.CategoryID,
                            Name = p.Name,
                            ImageLink = p.ImageLink
                        }
                  ).Distinct();

            return list.AsQueryable();
        }


        public IEnumerable<ProductView> GetProductsList()
        {
            return (from p in Entity.Products
                    where (p.Stock > 0) && (p.isActive == true)
                    select new ProductView
                    {
                        ProductID = p.ProductID,
                        Name = p.Name,
                        Description = p.Description,
                        CategoryID = p.CategoryID,
                        ImageLink = p.ImageLink,
                        Price = p.Price,
                        Username = p.Username,
                        Stock = p.Stock,
                        isActive = p.isActive
                    }).ToList();
        }

        public ProductView GetProductV(int id)
        {
            return (from p in Entity.Products
                    where p.ProductID == id
                    select new ProductView
                    {
                        ProductID = p.ProductID,
                        Name = p.Name,
                        Description = p.Description,
                        CategoryID = p.CategoryID,
                        ImageLink = p.ImageLink,
                        Price = p.Price,
                        Username = p.Username,
                        Stock = p.Stock,
                        isActive = p.isActive
                    }).FirstOrDefault();
        }

        public Product GetProduct(int id)
        {
            return Entity.Products.SingleOrDefault(x => x.ProductID == id);
        }

        public int GetProductID(string name)
        {
            return (from p in Entity.Products
                    where p.Name == name
                    select p.ProductID
                     ).SingleOrDefault();
        }

        public IQueryable<ProductView> GetProductsAccordingToSubCategory(System.Nullable<int> id)
        {
            var list = (from p in Entity.Products
                        where (p.CategoryID == id) && (p.Stock > 0) && (p.isActive == true)
                        select new ProductView
                       {
                           ProductID = p.ProductID,
                           Name = p.Name,
                           Description = p.Description,
                           CategoryID = p.CategoryID,
                           ImageLink = p.ImageLink,
                           Price = p.Price,
                           Username = p.Username,
                           Stock = p.Stock,
                           isActive = p.isActive
                       });

            return list.AsQueryable();
        }

        public IQueryable<ProductView> GetProductsAccordingToSeller(string username)
        {
            var list = (from p in Entity.Products
                        where p.Username == username
                        select new ProductView
                        {
                            ProductID = p.ProductID,
                            Name = p.Name,
                            Description = p.Description,
                            CategoryID = p.CategoryID,
                            ImageLink = p.ImageLink,
                            Price = p.Price,
                            Username = p.Username,
                            Stock = p.Stock,
                            isActive = p.isActive
                        });

            return list.AsQueryable();
        }

        public void ControlStock(int productid, int stock)
        {
            Product ps = GetProduct(productid);
            ps.Stock += stock;
            Entity.SaveChanges();
        }
        


        public bool CheckStock(int productid, int stock)
        {
            Product c = GetProduct(productid);

            if ((c.Stock - stock) <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public int GetStock(int productID)
        {
            var thisc =  (from p in Entity.Products
                    where p.ProductID == productID
                    select p.Stock
                    ).SingleOrDefault();

            return Convert.ToInt16(thisc);

        }

        public void AddToCart(Cart cart)
        {
            Entity.Carts.Add(cart);
            Entity.SaveChanges();
        }

        public Cart GetShoppingCart(string username, int productId)
        {
            return Entity.Carts.SingleOrDefault(x => x.Username == username && x.ProductID == productId);
        }

        public void UpdateCart(string username, int productId, int newQty)
        {
            Cart sc = GetShoppingCart(username, productId);
            sc.Quantity += newQty;
            Entity.SaveChanges();
        }

        public void DecrementCart(string username, int productId)
        {
            Cart sc = GetShoppingCart(username, productId);
            sc.Quantity = sc.Quantity - 1;
            Entity.SaveChanges();
        }

        public IQueryable<ShoppingCartView> GetProductsinShoppingCart(string Username)
        {
            return (from sc in Entity.Carts
                    join p in Entity.Products
                    on sc.ProductID equals p.ProductID
                    where sc.Username == Username
                    select new ShoppingCartView
                    {
                        ProductID = p.ProductID,
                        Name = p.Name,
                        Price = p.Price,
                        Quantity = sc.Quantity,
                        ImageLink = p.ImageLink
                    }
                    );
        }

        public void DeleteShoppingCartEntry(Cart sc)
        {
            Entity.Carts.Remove(sc);
            Entity.SaveChanges();
        }

        public int GetNoOfItemsInShoppingCartEntry(string username, int productid)
        {
            if (Entity.Carts.Where(s => s.Username == username && s.ProductID == productid).Count() == 0)
                return 0;
            else return Entity.Carts.Where(s => s.Username == username && s.ProductID == productid).Sum(x => x.Quantity);
        }

        public void AddProduct(Product newProduct)
        {
            Entity.Products.Add(newProduct);
            Entity.SaveChanges();
        }

        public void UpdateProduct(Product PtoUpdate)
        {
            Product originalprod = GetProduct(PtoUpdate.ProductID);
            Entity.Products.Attach(originalprod);
            ((IObjectContextAdapter)Entity).ObjectContext.ApplyCurrentValues("Products", originalprod);
            Entity.SaveChanges();
        }

        public void DeleteProduct(int productid)
        {
            Product thisp = GetProduct(productid);
            Product updatedp = thisp;
            if (thisp.isActive == false)
            {
                updatedp.isActive = true;
            }
            else { 
            updatedp.isActive = false;
            }
            Entity.Entry(thisp).CurrentValues.SetValues(thisp);
            //Entity.Products.Attach(thisp);
            //((IObjectContextAdapter)Entity).ObjectContext.ApplyCurrentValues("Products", thisp);
            Entity.SaveChanges();
        }

        public void MarkActive(int productid)
        {
            Product thisp = GetProduct(productid);
            Product updatedp = thisp;
            updatedp.isActive = true;
            Entity.Entry(thisp).CurrentValues.SetValues(thisp);
            Entity.SaveChanges();
        }




    }
}
