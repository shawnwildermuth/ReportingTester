using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ReportingTester.Data.Entities;

namespace ReportingTester.Data;

public partial class StoreDbContext : DbContext
{
  public StoreDbContext()
  {
  }

  public StoreDbContext(DbContextOptions<StoreDbContext> options)
      : base(options)
  {
  }

  public virtual DbSet<Brand> Brands => Set<Brand>();
  public virtual DbSet<Category> Categories => Set<Category>();
  public virtual DbSet<Customer> Customers => Set<Customer>();
  public virtual DbSet<Order> Orders => Set<Order>();
  public virtual DbSet<OrderItem> OrderItems => Set<OrderItem>();
  public virtual DbSet<Product> Products => Set<Product>();
  public virtual DbSet<Staff> Staffs => Set<Staff>();
  public virtual DbSet<Stock> Stocks => Set<Stock>();
  public virtual DbSet<Store> Stores => Set<Store>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Brand>(entity =>
    {
      entity.HasKey(e => e.BrandId).HasName("PK__brands__5E5A8E278898FD59");

      entity.ToTable("brands", "production");

      entity.Property(e => e.BrandId).HasColumnName("brand_id");
      entity.Property(e => e.BrandName)
              .HasMaxLength(255)
              .IsUnicode(false)
              .HasColumnName("brand_name");
    });

    modelBuilder.Entity<Category>(entity =>
    {
      entity.HasKey(e => e.CategoryId).HasName("PK__categori__D54EE9B4D881E0CA");

      entity.ToTable("categories", "production");

      entity.Property(e => e.CategoryId).HasColumnName("category_id");
      entity.Property(e => e.CategoryName)
              .HasMaxLength(255)
              .IsUnicode(false)
              .HasColumnName("category_name");
    });

    modelBuilder.Entity<Customer>(entity =>
    {
      entity.HasKey(e => e.CustomerId).HasName("PK__customer__CD65CB85DE5BF816");

      entity.ToTable("customers", "sales");

      entity.Property(e => e.CustomerId).HasColumnName("customer_id");
      entity.Property(e => e.City)
              .HasMaxLength(50)
              .IsUnicode(false)
              .HasColumnName("city");
      entity.Property(e => e.Email)
              .HasMaxLength(255)
              .IsUnicode(false)
              .HasColumnName("email");
      entity.Property(e => e.FirstName)
              .HasMaxLength(255)
              .IsUnicode(false)
              .HasColumnName("first_name");
      entity.Property(e => e.LastName)
              .HasMaxLength(255)
              .IsUnicode(false)
              .HasColumnName("last_name");
      entity.Property(e => e.Phone)
              .HasMaxLength(25)
              .IsUnicode(false)
              .HasColumnName("phone");
      entity.Property(e => e.State)
              .HasMaxLength(25)
              .IsUnicode(false)
              .HasColumnName("state");
      entity.Property(e => e.Street)
              .HasMaxLength(255)
              .IsUnicode(false)
              .HasColumnName("street");
      entity.Property(e => e.ZipCode)
              .HasMaxLength(5)
              .IsUnicode(false)
              .HasColumnName("zip_code");
    });

    modelBuilder.Entity<Order>(entity =>
    {
      entity.HasKey(e => e.OrderId).HasName("PK__orders__4659622989BE68BD");

      entity.ToTable("orders", "sales");

      entity.Property(e => e.OrderId).HasColumnName("order_id");
      entity.Property(e => e.CustomerId).HasColumnName("customer_id");
      entity.Property(e => e.OrderDate)
              .HasColumnType("date")
              .HasColumnName("order_date");
      entity.Property(e => e.OrderStatus).HasColumnName("order_status");
      entity.Property(e => e.RequiredDate)
              .HasColumnType("date")
              .HasColumnName("required_date");
      entity.Property(e => e.ShippedDate)
              .HasColumnType("date")
              .HasColumnName("shipped_date");
      entity.Property(e => e.StaffId).HasColumnName("staff_id");
      entity.Property(e => e.StoreId).HasColumnName("store_id");

      entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
              .HasForeignKey(d => d.CustomerId)
              .OnDelete(DeleteBehavior.Cascade)
              .HasConstraintName("FK__orders__customer__34C8D9D1");

      entity.HasOne(d => d.Staff).WithMany(p => p.Orders)
              .HasForeignKey(d => d.StaffId)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK__orders__staff_id__36B12243");

      entity.HasOne(d => d.Store).WithMany(p => p.Orders)
              .HasForeignKey(d => d.StoreId)
              .HasConstraintName("FK__orders__store_id__35BCFE0A");
    });

    modelBuilder.Entity<OrderItem>(entity =>
    {
      entity.HasKey(e => new { e.OrderId, e.ItemId }).HasName("PK__order_it__837942D4CBB62FFA");

      entity.ToTable("order_items", "sales");

      entity.Property(e => e.OrderId).HasColumnName("order_id");
      entity.Property(e => e.ItemId).HasColumnName("item_id");
      entity.Property(e => e.Discount)
              .HasColumnType("decimal(4, 2)")
              .HasColumnName("discount");
      entity.Property(e => e.ListPrice)
              .HasColumnType("decimal(10, 2)")
              .HasColumnName("list_price");
      entity.Property(e => e.ProductId).HasColumnName("product_id");
      entity.Property(e => e.Quantity).HasColumnName("quantity");

      entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
              .HasForeignKey(d => d.OrderId)
              .HasConstraintName("FK__order_ite__order__3A81B327");

      entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
              .HasForeignKey(d => d.ProductId)
              .HasConstraintName("FK__order_ite__produ__3B75D760");
    });

    modelBuilder.Entity<Product>(entity =>
    {
      entity.HasKey(e => e.ProductId).HasName("PK__products__47027DF5F2120993");

      entity.ToTable("products", "production");

      entity.Property(e => e.ProductId).HasColumnName("product_id");
      entity.Property(e => e.BrandId).HasColumnName("brand_id");
      entity.Property(e => e.CategoryId).HasColumnName("category_id");
      entity.Property(e => e.ListPrice)
              .HasColumnType("decimal(10, 2)")
              .HasColumnName("list_price");
      entity.Property(e => e.ModelYear).HasColumnName("model_year");
      entity.Property(e => e.ProductName)
              .HasMaxLength(255)
              .IsUnicode(false)
              .HasColumnName("product_name");

      entity.HasOne(d => d.Brand).WithMany(p => p.Products)
              .HasForeignKey(d => d.BrandId)
              .HasConstraintName("FK__products__brand___29572725");

      entity.HasOne(d => d.Category).WithMany(p => p.Products)
              .HasForeignKey(d => d.CategoryId)
              .HasConstraintName("FK__products__catego__286302EC");
    });

    modelBuilder.Entity<Staff>(entity =>
    {
      entity.HasKey(e => e.StaffId).HasName("PK__staffs__1963DD9CB36E7D1F");

      entity.ToTable("staffs", "sales");

      entity.HasIndex(e => e.Email, "UQ__staffs__AB6E61647A6A3DCC").IsUnique();

      entity.Property(e => e.StaffId).HasColumnName("staff_id");
      entity.Property(e => e.Active).HasColumnName("active");
      entity.Property(e => e.Email)
              .HasMaxLength(255)
              .IsUnicode(false)
              .HasColumnName("email");
      entity.Property(e => e.FirstName)
              .HasMaxLength(50)
              .IsUnicode(false)
              .HasColumnName("first_name");
      entity.Property(e => e.LastName)
              .HasMaxLength(50)
              .IsUnicode(false)
              .HasColumnName("last_name");
      entity.Property(e => e.ManagerId).HasColumnName("manager_id");
      entity.Property(e => e.Phone)
              .HasMaxLength(25)
              .IsUnicode(false)
              .HasColumnName("phone");
      entity.Property(e => e.StoreId).HasColumnName("store_id");

      entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager)
              .HasForeignKey(d => d.ManagerId)
              .HasConstraintName("FK__staffs__manager___31EC6D26");

      entity.HasOne(d => d.Store).WithMany(p => p.Staff)
              .HasForeignKey(d => d.StoreId)
              .HasConstraintName("FK__staffs__store_id__30F848ED");
    });

    modelBuilder.Entity<Stock>(entity =>
    {
      entity.HasKey(e => new { e.StoreId, e.ProductId }).HasName("PK__stocks__E68284D36E386F36");

      entity.ToTable("stocks", "production");

      entity.Property(e => e.StoreId).HasColumnName("store_id");
      entity.Property(e => e.ProductId).HasColumnName("product_id");
      entity.Property(e => e.Quantity).HasColumnName("quantity");

      entity.HasOne(d => d.Product).WithMany(p => p.Stocks)
              .HasForeignKey(d => d.ProductId)
              .HasConstraintName("FK__stocks__product___3F466844");

      entity.HasOne(d => d.Store).WithMany(p => p.Stocks)
              .HasForeignKey(d => d.StoreId)
              .HasConstraintName("FK__stocks__store_id__3E52440B");
    });

    modelBuilder.Entity<Store>(entity =>
    {
      entity.HasKey(e => e.StoreId).HasName("PK__stores__A2F2A30C2AD13990");

      entity.ToTable("stores", "sales");

      entity.Property(e => e.StoreId).HasColumnName("store_id");
      entity.Property(e => e.City)
              .HasMaxLength(255)
              .IsUnicode(false)
              .HasColumnName("city");
      entity.Property(e => e.Email)
              .HasMaxLength(255)
              .IsUnicode(false)
              .HasColumnName("email");
      entity.Property(e => e.Phone)
              .HasMaxLength(25)
              .IsUnicode(false)
              .HasColumnName("phone");
      entity.Property(e => e.State)
              .HasMaxLength(10)
              .IsUnicode(false)
              .HasColumnName("state");
      entity.Property(e => e.StoreName)
              .HasMaxLength(255)
              .IsUnicode(false)
              .HasColumnName("store_name");
      entity.Property(e => e.Street)
              .HasMaxLength(255)
              .IsUnicode(false)
              .HasColumnName("street");
      entity.Property(e => e.ZipCode)
              .HasMaxLength(5)
              .IsUnicode(false)
              .HasColumnName("zip_code");
    });

    OnModelCreatingPartial(modelBuilder);
  }

  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
