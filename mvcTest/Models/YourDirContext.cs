using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace mvcTest.Models
{
    public partial class YourDirContext : IdentityDbContext
    {
        public YourDirContext()
        {
        }

        public YourDirContext(DbContextOptions<YourDirContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activationtable> Activationtable { get; set; }
        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientPayment> ClientPayment { get; set; }
        public virtual DbSet<Datacollector> Datacollector { get; set; }
        public virtual DbSet<Datacollectorshop> Datacollectorshop { get; set; }
        public virtual DbSet<Dcpayment> Dcpayment { get; set; }
        public virtual DbSet<Itemstosale> Itemstosale { get; set; }
        public virtual DbSet<Joboffer> Joboffer { get; set; }
        public virtual DbSet<Jobrequest> Jobrequest { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<Offer> Offer { get; set; }
        public virtual DbSet<Referencepoint> Referencepoint { get; set; }
        public virtual DbSet<Saleoffer> Saleoffer { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<Shopitem> Shopitem { get; set; }
        public virtual DbSet<Shoptype> Shoptype { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=YourDirDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Activationtable>(entity =>
            {
                entity.HasKey(e => e.ActivationId);

                entity.ToTable("activationtable", "yourdir");

                entity.Property(e => e.ActivationDate).HasColumnType("date");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Activationtable)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_activationtable_shop");
            });

            modelBuilder.Entity<Banner>(entity =>
            {
                entity.Property(e => e.BannerId)
                    .HasColumnName("bannerId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Link)
                    .HasColumnName("link")
                    .HasMaxLength(150);

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasColumnName("photo")
                    .HasMaxLength(150);

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("date");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Banner)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Banner_client");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategorId);

                entity.ToTable("category", "yourdir");

                entity.Property(e => e.CategorId).HasColumnName("categorId");

                entity.Property(e => e.CategoryEname)
                    .IsRequired()
                    .HasColumnName("CategoryEName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryPhoto)
                    .IsRequired()
                    .HasColumnName("categoryPhoto")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client", "yourdir");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Macaddress)
                    .IsRequired()
                    .HasColumnName("MACaddress")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RealName)
                    .IsRequired()
                    .HasColumnName("realName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RegisterationDate)
                    .HasColumnName("registerationDate")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<ClientPayment>(entity =>
            {
                entity.HasKey(e => e.PaymentId);

                entity.Property(e => e.PaymentId).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("paymentDate")
                    .HasColumnType("date");

                entity.Property(e => e.Reason)
                    .HasColumnName("reason")
                    .HasMaxLength(200);

                entity.Property(e => e.Reciept).HasMaxLength(50);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientPayment)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_ClientPayment_client");
            });

            modelBuilder.Entity<Datacollector>(entity =>
            {
                entity.HasKey(e => e.Dcid);

                entity.ToTable("datacollector", "yourdir");

                entity.Property(e => e.Dcid).HasColumnName("DCID");

                entity.Property(e => e.AddinfDate)
                    .HasColumnName("addinfDate")
                    .HasColumnType("date");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Macaddress)
                    .IsRequired()
                    .HasColumnName("MACAddress")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasColumnName("mobile")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Zone)
                    .IsRequired()
                    .HasColumnName("zone")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Datacollectorshop>(entity =>
            {
                entity.HasKey(e => e.Dcsid);

                entity.ToTable("datacollectorshop", "yourdir");

                entity.Property(e => e.Dcsid).HasColumnName("DCSId");

                entity.Property(e => e.AddingDate)
                    .HasColumnName("addingDate")
                    .HasColumnType("date");

                entity.Property(e => e.Dcid).HasColumnName("DCId");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Macaddress)
                    .IsRequired()
                    .HasColumnName("MACAddress")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dc)
                    .WithMany(p => p.Datacollectorshop)
                    .HasForeignKey(d => d.Dcid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_datacollectorshop_datacollector");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Datacollectorshop)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_datacollectorshop_shop");
            });

            modelBuilder.Entity<Dcpayment>(entity =>
            {
                entity.ToTable("dcpayment", "yourdir");

                entity.Property(e => e.DcpaymentId).HasColumnName("DCPaymentID");

                entity.Property(e => e.Dcid).HasColumnName("DCID");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.RecNum).HasColumnName("recNum");

                entity.HasOne(d => d.Dc)
                    .WithMany(p => p.Dcpayment)
                    .HasForeignKey(d => d.Dcid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dcpayment_datacollector");
            });

            modelBuilder.Entity<Itemstosale>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.ToTable("itemstosale", "yourdir");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("CategoryId");

                entity.Property(e => e.Aname)
                    .IsRequired()
                    .HasColumnName("AName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ename)
                    .IsRequired()
                    .HasColumnName("EName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Itemstosale)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_itemstosale_category");
            });

            modelBuilder.Entity<Joboffer>(entity =>
            {
                entity.ToTable("joboffer", "yourdir");

                entity.HasIndex(e => e.ClientId)
                    .HasName("clientId");

                entity.Property(e => e.JobOfferId).HasColumnName("jobOfferId");

                entity.Property(e => e.ClientId).HasColumnName("clientId");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Days).HasColumnName("days");

                entity.Property(e => e.OfferDate)
                    .HasColumnName("offerDate")
                    .HasColumnType("date");

                entity.Property(e => e.OfferText)
                    .IsRequired()
                    .HasColumnName("offerText")
                    .IsUnicode(false);

                entity.Property(e => e.OfferTitle)
                    .IsRequired()
                    .HasColumnName("offerTitle")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Joboffer)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_joboffer_client");
            });

            modelBuilder.Entity<Jobrequest>(entity =>
            {
                entity.ToTable("jobrequest", "yourdir");

                entity.HasIndex(e => e.ClientId)
                    .HasName("clientId");

                entity.Property(e => e.ClientId).HasColumnName("clientId");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Days).HasColumnName("days");

                entity.Property(e => e.RequestDate)
                    .HasColumnName("requestDate")
                    .HasColumnType("date");

                entity.Property(e => e.RequestText)
                    .IsRequired()
                    .HasColumnName("requestText")
                    .IsUnicode(false);

                entity.Property(e => e.RequestTitle)
                    .IsRequired()
                    .HasColumnName("requestTitle")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Jobrequest)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_jobrequest_client");
            });

            modelBuilder.Entity<Logs>(entity =>
            {
                entity.ToTable("logs", "yourdir");

                entity.HasIndex(e => e.ClientId)
                    .HasName("ClientId");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LogDate).HasColumnType("date");

                entity.Property(e => e.MacAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_logs_client");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.ToTable("offer", "yourdir");

                entity.HasIndex(e => e.ShopId)
                    .HasName("shopId");

                entity.Property(e => e.ActivationDate)
                    .HasColumnName("activationDate")
                    .HasColumnType("date");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.OfferDate)
                    .HasColumnName("offerDate")
                    .HasColumnType("date");

                entity.Property(e => e.OfferText)
                    .IsRequired()
                    .HasColumnName("offerText")
                    .IsUnicode(false);

                entity.Property(e => e.OfferTitle)
                    .IsRequired()
                    .HasColumnName("offerTitle")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasColumnName("photo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ShopId).HasColumnName("shopId");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Offer)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_offer_client");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Offer)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_offer_shoptype");
            });

            modelBuilder.Entity<Referencepoint>(entity =>
            {
                entity.ToTable("referencepoint", "yourdir");

                entity.Property(e => e.ReferencePointId).HasColumnName("referencePointId");

                entity.Property(e => e.AName)
                    .IsRequired()
                    .HasColumnName("aName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EName)
                    .IsRequired()
                    .HasColumnName("eName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Saleoffer>(entity =>
            {
                entity.HasKey(e => e.Soid);

                entity.ToTable("saleoffer", "yourdir");

                entity.HasIndex(e => e.ClientId)
                    .HasName("UserId");

                entity.Property(e => e.Soid).HasColumnName("SOId");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.OfferText)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.OfferTitle)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasColumnName("photo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Saleoffer)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_saleoffer_client");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.ToTable("shop", "yourdir");

                entity.HasIndex(e => e.ReferencePointId)
                    .HasName("referencePointId");

                entity.HasIndex(e => e.ShopTypeId)
                    .HasName("ShopTypeId");

                entity.Property(e => e.ActivationDate).HasColumnType("date");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EshopName)
                    .IsRequired()
                    .HasColumnName("EShopName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Facebook)
                    .IsRequired()
                    .HasColumnName("facebook")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasColumnName("mobile")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("notes")
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Properties)
                    .IsRequired()
                    .HasColumnName("properties")
                    .IsUnicode(false);

                entity.Property(e => e.ReferencePointId).HasColumnName("referencePointId");

                entity.Property(e => e.RegisterationDate)
                    .HasColumnName("registerationDate")
                    .HasColumnType("date");

                entity.Property(e => e.ShopName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Twiter)
                    .IsRequired()
                    .HasColumnName("twiter")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .IsRequired()
                    .HasColumnName("website")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.ReferencePoint)
                    .WithMany(p => p.Shop)
                    .HasForeignKey(d => d.ReferencePointId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_shop_referencepoint");

                entity.HasOne(d => d.ShopType)
                    .WithMany(p => p.Shop)
                    .HasForeignKey(d => d.ShopTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_shop_shoptype");
            });

            modelBuilder.Entity<Shopitem>(entity =>
            {
                entity.ToTable("shopitem", "yourdir");

                entity.HasIndex(e => e.ItemId)
                    .HasName("itemId");

                entity.HasIndex(e => e.ShopId)
                    .HasName("ShopItemID");

                entity.Property(e => e.ItemId).HasColumnName("itemId");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Shopitem)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_shopitem_itemstosale");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Shopitem)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_shopitem_shop");
            });

            modelBuilder.Entity<Shoptype>(entity =>
            {
                entity.ToTable("shoptype", "yourdir");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("categoryId");

                entity.Property(e => e.Aliases)
                    .IsRequired()
                    .HasColumnName("aliases")
                    .IsUnicode(false);

                entity.Property(e => e.Aname)
                    .IsRequired()
                    .HasColumnName("AName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.Ealiases)
                    .IsRequired()
                    .HasColumnName("ealiases")
                    .IsUnicode(false);

                entity.Property(e => e.Ename)
                    .HasColumnName("EName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasColumnName("photo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Shoptype)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_shoptype_category");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
