using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MusicBlazorApp.Data;

public partial class MusicDbContext : DbContext
{
    public MusicDbContext()
    {
    }

    public MusicDbContext(DbContextOptions<MusicDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemCategory> ItemCategories { get; set; }

    public virtual DbSet<ItemImage> ItemImages { get; set; }

    public virtual DbSet<ItemRental> ItemRentals { get; set; }

    public virtual DbSet<ItemStatus> ItemStatuses { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<PurchaseItem> PurchaseItems { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomRental> RoomRentals { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=MusicDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("pg_catalog", "azure")
            .HasPostgresExtension("pg_catalog", "pgaadauth")
            .HasPostgresExtension("pg_cron");

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("brand_pkey");

            entity.ToTable("brand");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BrandDescription).HasColumnName("brand_description");
            entity.Property(e => e.BrandName)
                .HasMaxLength(50)
                .HasColumnName("brand_name");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(30)
                .HasColumnName("category_name");
            entity.Property(e => e.Description).HasColumnName("description");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customer_pkey");

            entity.ToTable("customer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(300)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(320)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
            entity.Property(e => e.RewardPoints).HasColumnName("reward_points");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employee_pkey");

            entity.ToTable("employee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(300)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(320)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");

            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("employee_manager_id_fkey");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("item_pkey");

            entity.ToTable("item");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ItemName)
                .HasMaxLength(100)
                .HasColumnName("item_name");
            entity.Property(e => e.SellPrice)
                .HasColumnType("money")
                .HasColumnName("sell_price");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(50)
                .HasColumnName("serial_number");
            entity.Property(e => e.SuggestedRentalPrice)
                .HasColumnType("money")
                .HasColumnName("suggested_rental_price");

            entity.HasOne(d => d.Brand).WithMany(p => p.Items)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("item_brand_id_fkey");
        });

        modelBuilder.Entity<ItemCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("item_category_pkey");

            entity.ToTable("item_category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.ItemId).HasColumnName("item_id");

            entity.HasOne(d => d.Category).WithMany(p => p.ItemCategories)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("item_category_category_id_fkey");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemCategories)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("item_category_item_id_fkey");
        });

        modelBuilder.Entity<ItemImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("item_image_pkey");

            entity.ToTable("item_image");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Filepath).HasColumnName("filepath");
            entity.Property(e => e.IsPrimary).HasColumnName("is_primary");
            entity.Property(e => e.ItemId).HasColumnName("item_id");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemImages)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("item_image_item_id_fkey");
        });

        modelBuilder.Entity<ItemRental>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("item_rental_pkey");

            entity.ToTable("item_rental");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FinalRentalPrice)
                .HasColumnType("money")
                .HasColumnName("final_rental_price");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.OutCondition).HasColumnName("out_condition");
            entity.Property(e => e.RentalId).HasColumnName("rental_id");
            entity.Property(e => e.ReturnDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("return_date");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemRentals)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("item_rental_item_id_fkey");

            entity.HasOne(d => d.Rental).WithMany(p => p.ItemRentals)
                .HasForeignKey(d => d.RentalId)
                .HasConstraintName("item_rental_rental_id_fkey");
        });

        modelBuilder.Entity<ItemStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("item_status_pkey");

            entity.ToTable("item_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsRentable).HasColumnName("is_rentable");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemStatuses)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("item_status_item_id_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.ItemStatuses)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("item_status_status_id_fkey");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("purchase_pkey");

            entity.ToTable("purchase");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchase_date");

            entity.HasOne(d => d.Customer).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("purchase_customer_id_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("purchase_employee_id_fkey");
        });

        modelBuilder.Entity<PurchaseItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("purchase_item_pkey");

            entity.ToTable("purchase_item");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FinalPrice)
                .HasColumnType("money")
                .HasColumnName("final_price");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Item).WithMany(p => p.PurchaseItems)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("purchase_item_item_id_fkey");

            entity.HasOne(d => d.Purchase).WithMany(p => p.PurchaseItems)
                .HasForeignKey(d => d.PurchaseId)
                .HasConstraintName("purchase_item_purchase_id_fkey");
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rental_pkey");

            entity.ToTable("rental");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.RentalDate).HasColumnName("rental_date");

            entity.HasOne(d => d.Customer).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("rental_customer_id_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("rental_employee_id_fkey");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("review_pkey");

            entity.ToTable("review");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ReviewDate).HasColumnName("review_date");
            entity.Property(e => e.ReviewText).HasColumnName("review_text");

            entity.HasOne(d => d.Customer).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("review_customer_id_fkey");

            entity.HasOne(d => d.Item).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("review_item_id_fkey");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("room_pkey");

            entity.ToTable("room");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MaxCapacity).HasColumnName("max_capacity");
            entity.Property(e => e.RoomName)
                .HasMaxLength(100)
                .HasColumnName("room_name");
            entity.Property(e => e.RoomTypeId).HasColumnName("room_type_id");

            entity.HasOne(d => d.RoomType).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.RoomTypeId)
                .HasConstraintName("room_room_type_id_fkey");
        });

        modelBuilder.Entity<RoomRental>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("room_rental_pkey");

            entity.ToTable("room_rental");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActualPrice)
                .HasColumnType("money")
                .HasColumnName("actual_price");
            entity.Property(e => e.EndTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_time");
            entity.Property(e => e.RentalId).HasColumnName("rental_id");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.StartTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_time");

            entity.HasOne(d => d.Rental).WithMany(p => p.RoomRentals)
                .HasForeignKey(d => d.RentalId)
                .HasConstraintName("room_rental_rental_id_fkey");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomRentals)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("room_rental_room_id_fkey");
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("room_type_pkey");

            entity.ToTable("room_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BasePrice)
                .HasColumnType("money")
                .HasColumnName("base_price");
            entity.Property(e => e.RoomTypeName)
                .HasMaxLength(50)
                .HasColumnName("room_type_name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("status_pkey");

            entity.ToTable("status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(100)
                .HasColumnName("status_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
