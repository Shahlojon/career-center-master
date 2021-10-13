using AutoMapper;
using CareerCenter.Core.Models;
using CareerCenter.MVC.Models;


namespace CareerCenter.MVC.Mapper
{
    public class MyMapper:Profile
    {
        public MyMapper()
        {
            CreateMap<Announcement, AnnouncementView>();
            CreateMap<AnnouncementView, Announcement>();

            CreateMap<AnnouncementCategory, AnnouncementCategoryView>();
            CreateMap<AnnouncementCategoryView, AnnouncementCategory>();

            CreateMap<Article, ArticleView>();
            CreateMap<ArticleView, Article>();

            CreateMap<Faq, FaqView>();
            CreateMap<FaqView, Faq>();

            CreateMap<FaqCategory, FaqCategoryView>();
            CreateMap<FaqCategoryView, FaqCategory>();

            CreateMap<Gallery, GalleryView>();
            CreateMap<GalleryView, Gallery>();

            CreateMap<Group, GroupView>();
            CreateMap<GroupView, Group>();

            CreateMap<NotableStudent, NotableStudentView>();
            CreateMap<NotableStudentView, NotableStudent>();

            CreateMap<Partner, PartnerView>();
            CreateMap<PartnerView, Partner>();

            CreateMap<PartnerCategory, PartnerCategoryView>();
            CreateMap<PartnerCategoryView, PartnerCategory>();

            CreateMap<Post, PostView>();
            CreateMap<PostView, Post>();
           
            CreateMap<PostCategory, PostCategoryView>();
            CreateMap<PostCategoryView, PostCategory>();

            CreateMap<PostCommentView, PostComment>();
            CreateMap<PostComment, PostCommentView>();

            CreateMap<Regulation, RegulationView>();
            CreateMap<RegulationView, Regulation>();

            CreateMap<RegulationCategory, RegulationCategoryView>();
            CreateMap<RegulationCategoryView, RegulationCategory>();

            CreateMap<Service, ServiceView>();
            CreateMap<ServiceView, Service>();

            CreateMap<Settings, SettingsView>();
            CreateMap<SettingsView, Settings>();

            CreateMap<SlideShow, SlideShowView>();
            CreateMap<SlideShowView, SlideShow>();

            CreateMap<User, UserView>();
            CreateMap<UserView, User>();
            
            
            CreateMap<Role, RoleView>();
            CreateMap<RoleView, Role>();

            CreateMap<News, NewsView>();
            CreateMap<NewsView, News>();

            CreateMap<Vacancy, VacancyView>();
            CreateMap<VacancyView, Vacancy>();

            CreateMap<VacancyCategory, VacancyCategoryView>();
            CreateMap<VacancyCategoryView, VacancyCategory>();

            CreateMap<University, UniversityView>();
            CreateMap<UniversityView, University>();

            CreateMap<Faculty, FacultyView>();
            CreateMap<FacultyView, Faculty>();

            CreateMap<Contract, ContractView>();
            CreateMap<ContractView, Contract>();
        }

    }
}
