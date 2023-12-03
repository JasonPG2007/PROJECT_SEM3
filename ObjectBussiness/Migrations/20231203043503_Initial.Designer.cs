﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ObjectBussiness;

#nullable disable

namespace ObjectBussiness.Migrations
{
    [DbContext(typeof(PetroleumBusinessDBContext))]
    [Migration("20231203043503_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ObjectBussiness.Account", b =>
                {
                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<int>("ExamID")
                        .HasColumnType("int");

                    b.Property<int>("ExamRegisterID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountID");

                    b.HasIndex("ExamID");

                    b.HasIndex("ExamRegisterID")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ObjectBussiness.Decentralization", b =>
                {
                    b.Property<int>("DecentralizationID")
                        .HasColumnType("int");

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<DateTime>("RoleGrantDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.HasKey("DecentralizationID");

                    b.HasIndex("AccountID")
                        .IsUnique();

                    b.HasIndex("RoleID");

                    b.ToTable("Decentralizations");
                });

            modelBuilder.Entity("ObjectBussiness.Elect", b =>
                {
                    b.Property<int>("ElectID")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ElectID");

                    b.ToTable("Elects");

                    b.HasData(
                        new
                        {
                            ElectID = 1,
                            Status = true
                        },
                        new
                        {
                            ElectID = 2,
                            Status = false
                        });
                });

            modelBuilder.Entity("ObjectBussiness.Exam", b =>
                {
                    b.Property<int>("ExamID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreateTest")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeBegin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TimeDelay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeEnd")
                        .HasColumnType("datetime2");

                    b.HasKey("ExamID");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("ObjectBussiness.ExamRegister", b =>
                {
                    b.Property<int>("ExamRegisterID")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("CandidateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfBirth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResidentialAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExamRegisterID");

                    b.ToTable("ExamRegister");
                });

            modelBuilder.Entity("ObjectBussiness.History", b =>
                {
                    b.Property<int>("HistoryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("HistoryID");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("ObjectBussiness.News", b =>
                {
                    b.Property<int>("NewsID")
                        .HasColumnType("int");

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Contents")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateSubmitted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NewsID");

                    b.HasIndex("AccountID");

                    b.HasIndex("CategoryID");

                    b.ToTable("News");
                });

            modelBuilder.Entity("ObjectBussiness.NewsCategory", b =>
                {
                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("NewsCategories");

                    b.HasData(
                        new
                        {
                            CategoryID = 510837706,
                            CategoryName = "Gasoline Prices"
                        },
                        new
                        {
                            CategoryID = 660807154,
                            CategoryName = "Recruitment Jobs"
                        });
                });

            modelBuilder.Entity("ObjectBussiness.Question", b =>
                {
                    b.Property<int>("QuestionID")
                        .HasColumnType("int");

                    b.Property<string>("AnswerA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnswerB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnswerC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnswerD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorrectAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateMake")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExamID")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Point")
                        .HasColumnType("float");

                    b.Property<string>("QuestionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionID");

                    b.HasIndex("ExamID");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("ObjectBussiness.ResultCandidate", b =>
                {
                    b.Property<int>("ResultCandidateID")
                        .HasColumnType("int");

                    b.Property<int>("ElectID")
                        .HasColumnType("int");

                    b.Property<int>("ExamID")
                        .HasColumnType("int");

                    b.Property<int?>("HistoryID")
                        .HasColumnType("int");

                    b.HasKey("ResultCandidateID");

                    b.HasIndex("ElectID");

                    b.HasIndex("ExamID");

                    b.HasIndex("HistoryID");

                    b.ToTable("ResultCandidates");
                });

            modelBuilder.Entity("ObjectBussiness.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleID = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleID = 2,
                            RoleName = "Candidate"
                        });
                });

            modelBuilder.Entity("ObjectBussiness.Round", b =>
                {
                    b.Property<int>("RoundID")
                        .HasColumnType("int");

                    b.Property<int>("ExamID")
                        .HasColumnType("int");

                    b.Property<int>("RoundNumber")
                        .HasColumnType("int");

                    b.HasKey("RoundID");

                    b.HasIndex("ExamID");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("ObjectBussiness.Account", b =>
                {
                    b.HasOne("ObjectBussiness.Exam", "Exam")
                        .WithMany("Account")
                        .HasForeignKey("ExamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObjectBussiness.ExamRegister", "ExamRegister")
                        .WithOne("Account")
                        .HasForeignKey("ObjectBussiness.Account", "ExamRegisterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("ExamRegister");
                });

            modelBuilder.Entity("ObjectBussiness.Decentralization", b =>
                {
                    b.HasOne("ObjectBussiness.Account", "Account")
                        .WithOne("Decentralization")
                        .HasForeignKey("ObjectBussiness.Decentralization", "AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObjectBussiness.Role", "Role")
                        .WithMany("Decentralizations")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ObjectBussiness.News", b =>
                {
                    b.HasOne("ObjectBussiness.Account", "Account")
                        .WithMany("News")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObjectBussiness.NewsCategory", "Category")
                        .WithMany("News")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ObjectBussiness.Question", b =>
                {
                    b.HasOne("ObjectBussiness.Exam", "Exam")
                        .WithMany("Question")
                        .HasForeignKey("ExamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("ObjectBussiness.ResultCandidate", b =>
                {
                    b.HasOne("ObjectBussiness.Elect", "Elect")
                        .WithMany("ResultCandidate")
                        .HasForeignKey("ElectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObjectBussiness.Exam", "Exam")
                        .WithMany("ResultCandidate")
                        .HasForeignKey("ExamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObjectBussiness.History", null)
                        .WithMany("ResultCandidates")
                        .HasForeignKey("HistoryID");

                    b.Navigation("Elect");

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("ObjectBussiness.Round", b =>
                {
                    b.HasOne("ObjectBussiness.Exam", "Exam")
                        .WithMany("Round")
                        .HasForeignKey("ExamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("ObjectBussiness.Account", b =>
                {
                    b.Navigation("Decentralization");

                    b.Navigation("News");
                });

            modelBuilder.Entity("ObjectBussiness.Elect", b =>
                {
                    b.Navigation("ResultCandidate");
                });

            modelBuilder.Entity("ObjectBussiness.Exam", b =>
                {
                    b.Navigation("Account");

                    b.Navigation("Question");

                    b.Navigation("ResultCandidate");

                    b.Navigation("Round");
                });

            modelBuilder.Entity("ObjectBussiness.ExamRegister", b =>
                {
                    b.Navigation("Account");
                });

            modelBuilder.Entity("ObjectBussiness.History", b =>
                {
                    b.Navigation("ResultCandidates");
                });

            modelBuilder.Entity("ObjectBussiness.NewsCategory", b =>
                {
                    b.Navigation("News");
                });

            modelBuilder.Entity("ObjectBussiness.Role", b =>
                {
                    b.Navigation("Decentralizations");
                });
#pragma warning restore 612, 618
        }
    }
}
