﻿// // <auto-generated />
// using System;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Infrastructure;
// using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
// using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
// using Taskforce.Db;

// #nullable disable

// namespace Taskforce.Db.Migrations
// {
//     [DbContext(typeof(TaskforceDbContext))]
//     partial class TaskforceDbContextModelSnapshot : ModelSnapshot
//     {
//         protected override void BuildModel(ModelBuilder modelBuilder)
//         {
// #pragma warning disable 612, 618
//             modelBuilder
//                 .HasAnnotation("ProductVersion", "7.0.5")
//                 .HasAnnotation("Relational:MaxIdentifierLength", 63);

//             NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

//             modelBuilder.Entity("Taskforce.Db.Entities.Event", b =>
//                 {
//                     b.Property<Guid>("Id")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("uuid");

//                     b.Property<DateTime>("CreatedDate")
//                         .HasColumnType("timestamp with time zone");

//                     b.Property<DateTime?>("DeletedDate")
//                         .HasColumnType("timestamp with time zone");

//                     b.Property<string>("Description")
//                         .HasColumnType("text");

//                     b.Property<DateTime?>("EndDate")
//                         .HasColumnType("timestamp with time zone");

//                     b.Property<bool>("IsTemplate")
//                         .HasColumnType("boolean");

//                     b.Property<DateTime?>("StartDate")
//                         .HasColumnType("timestamp with time zone");

//                     b.Property<string>("Title")
//                         .HasColumnType("text");

//                     b.Property<string>("Type")
//                         .HasColumnType("text");

//                     b.Property<DateTime?>("UpdatedDate")
//                         .HasColumnType("timestamp with time zone");

//                     b.HasKey("Id");

//                     b.ToTable("Events");
//                 });

//             modelBuilder.Entity("Taskforce.Db.Entities.Ticket", b =>
//                 {
//                     b.Property<Guid>("Id")
//                         .ValueGeneratedOnAdd()
//                         .HasColumnType("uuid");

//                     b.Property<DateTime>("CreatedDate")
//                         .HasColumnType("timestamp with time zone");

//                     b.Property<DateTime?>("DeletedDate")
//                         .HasColumnType("timestamp with time zone");

//                     b.Property<string>("Description")
//                         .HasColumnType("text");

//                     b.Property<string>("Discriminator")
//                         .IsRequired()
//                         .HasColumnType("text");

//                     b.Property<bool>("IsTemplate")
//                         .HasColumnType("boolean");

//                     b.Property<string>("State")
//                         .HasColumnType("text");

//                     b.Property<string>("Title")
//                         .HasColumnType("text");

//                     b.Property<DateTime?>("UpdatedDate")
//                         .HasColumnType("timestamp with time zone");

//                     b.HasKey("Id");

//                     b.ToTable("Tickets");

//                     b.HasDiscriminator<string>("Discriminator").HasValue("Ticket");

//                     b.UseTphMappingStrategy();
//                 });

//             modelBuilder.Entity("Taskforce.Db.Entities.Task", b =>
//                 {
//                     b.HasBaseType("Taskforce.Db.Entities.Ticket");

//                     b.Property<DateTime?>("CompletedDate")
//                         .HasColumnType("timestamp with time zone");

//                     b.Property<DateTime?>("DueDate")
//                         .HasColumnType("timestamp with time zone");

//                     b.HasDiscriminator().HasValue("Task");
//                 });
// #pragma warning restore 612, 618
//         }
//     }
// }
