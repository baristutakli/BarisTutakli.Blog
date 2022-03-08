using System;
using Xunit;
using Moq;
using BarisTutakli.Blog.DomainServices.Interfaces;
using Blog.Application.Interfaces;
using Blog.Application.Concrete;
using AutoMapper;
using BarisTutakli.Blog.Application.Models.CategoryModels;
using BarisTutakli.Blog.Domain.Entities;
using BarisTutakli.Blog.Application.Tools.MappingProfiles;

namespace BarisTutakli.Blog.ApplicationTest
{
    public class CategoriesServiceUnitTest
    {
        Mock<IUnitOfWork> _unitOfWorkMock;
        CategoryService _categoryService;
        IMapper _mapper;

        public CategoriesServiceUnitTest()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CategoryMappingProfile());
            });
            _mapper = mappingConfig.CreateMapper();
            _categoryService = new CategoryService(_unitOfWorkMock.Object,_mapper);
        }

        [Fact]
        public void Add_Category_ReturnsBoolean()
        {
            //Arrange
            CreateCategoryModel createCategoryModel = new CreateCategoryModel() { Body="asdasda", MetaTitle="c#", Title="Hello world" };
            var category = _mapper.Map<Category>(createCategoryModel);
            _unitOfWorkMock.Setup(unitOfWork => unitOfWork.Categories.Add(It.IsAny<Category>()));
            _unitOfWorkMock.Setup(unitOfWork => unitOfWork.Complete()).Returns(1);

            // Act

            _unitOfWorkMock.Object.Categories.Add(category);
            var affectedRows = _unitOfWorkMock.Object.Complete();

            //Assert
            Assert.IsType < Category>(category);
            Assert.True(affectedRows > 0);
        }

        [Fact]
        public void Get_Category_ReturnsGetCategoryModel()
        {
            //Arrange
            GetCategoryModel categoryModel;
            var category = _unitOfWorkMock.Setup(unitOfWork => unitOfWork.Categories.Get(c => c.Id == 1).Result).Returns(new Category() { Id = 1, Body = "asdasda", Title = "title", MetaTitle="aaaaa" , CreatedAt= DateTime.Parse(DateTime.Now.ToShortDateString()),IsActive=true });
            
            // Act

            _unitOfWorkMock.Object.Categories.Get(c=>c.Id==1);
            categoryModel = _mapper.Map<GetCategoryModel>(category);

            //Assert
            Assert.IsType<GetCategoryModel>(categoryModel);
            Assert.NotNull(category);
            Assert.NotNull(categoryModel);
            
        }
    }
}
