using Microsoft.EntityFrameworkCore;
using Personality.Blog;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Personality.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class PersonalityDbContext :
    AbpDbContext<PersonalityDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public DbSet<Post> Posts { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<TagPost> TagPosts { get; set; }
    public DbSet<CategoryPost> CategoryPosts { get; set; }
    
    public PersonalityDbContext(DbContextOptions<PersonalityDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        builder.Entity<Post>(b =>
        {
            b.ToTable(PersonalityConsts.DbTablePrefix + "Posts", PersonalityConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.HasMany(x => x.Tags)
                .WithMany(x => x.Posts)
                .UsingEntity(x => x.ToTable("TagPosts"));
        });
        
        builder.Entity<Tag>(b =>
        {
            b.ToTable(PersonalityConsts.DbTablePrefix + "Tags", PersonalityConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.HasMany(x => x.Posts)
                .WithMany(x => x.Tags)
                .UsingEntity(x => x.ToTable("TagPosts"));
        });
        
        builder.Entity<Category>(b =>
        {
            b.ToTable(PersonalityConsts.DbTablePrefix + "Categorys", PersonalityConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.HasMany(x => x.Posts)
                .WithMany(x => x.Categories)
                .UsingEntity(x => x.ToTable("CategoryPosts"));
        });
        
        builder.Entity<TagPost>(b =>
        {
            b.ToTable(PersonalityConsts.DbTablePrefix + "TagPosts", PersonalityConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.HasKey(x => new { x.TagId, x.PostId });
            b.HasOne(x => x.Tag)
                .WithMany(x => x.TagsPosts)
                .HasForeignKey(x => x.TagId);
        });
        
        
        builder.Entity<CategoryPost>(b =>
        {
            b.ToTable(PersonalityConsts.DbTablePrefix + "CategoryPosts", PersonalityConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.HasKey(x => new { x.CategoryId, x.PostId });
            b.HasOne(x => x.Category)
                .WithMany(x => x.CategoryPosts)
                .HasForeignKey(x => x.CategoryId);
        });
    }
}
