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
using System.Collections.Generic;
using System.Threading.Tasks;
using MoqExpression;
using System.Linq.Expressions;
using System.Linq;

namespace BarisTutakli.Blog.ApplicationTest
{
    //public class CategoriesServiceUnitTest
    //{
    //    Mock<IUnitOfWork> _unitOfWorkMock;
    //    CategoryService _categoryService;
       
    //    IMapper _mapper;
    //    List<Category> _categoryList = new List<Category>() {
    //    new Category() { Id = 1, Body = "asdasda", Title = "title", MetaTitle = "aaaaa", IsActive = true},
    //            new Category() { Id = 2, Body = "asdasda", Title = "title", MetaTitle = "aaaaa", IsActive = true},
    //            new Category() { Id = 3, Body = "asdasda", Title = "title", MetaTitle = "aaaaa", IsActive = true}
    //    };

    //    public CategoriesServiceUnitTest()
    //    {
    //        _unitOfWorkMock = new Mock<IUnitOfWork>();
    //        var mappingConfig = new MapperConfiguration(mc =>
    //        {
    //            mc.AddProfile(new CategoryMappingProfile());
    //        });
    //        _mapper = mappingConfig.CreateMapper();


    //        _categoryService = new CategoryService(_unitOfWorkMock.Object,_mapper);
    //    }

    //    [Fact]
    //    public void Add_Category_ReturnsBoolean()
    //    {
    //        //Arrange
    //        CreateCategoryModel createCategoryModel = new CreateCategoryModel() { Body="asdasda", MetaTitle="c#", Title="Hello world" };
    //        var category = _mapper.Map<Category>(createCategoryModel);
    //        _unitOfWorkMock.Setup(unitOfWork => unitOfWork.Categories.Add(It.IsAny<Category>()));
    //        _unitOfWorkMock.Setup(unitOfWork => unitOfWork.Complete()).Returns(1);

    //        // Act

    //        _unitOfWorkMock.Object.Categories.Add(category);
    //        var affectedRows = _unitOfWorkMock.Object.Complete();

    //        //Assert
    //        Assert.IsType < Category>(category);
    //        Assert.True(affectedRows > 0);
    //    }

    //    [Fact]
    //    public void Update_Category_ReturnsBoolean()
    //    {
    //        //Arrange
    //        UpdateCategoryModel updateCategoryModel = new UpdateCategoryModel() { Body = "asdasda", MetaTitle = "c#", Title = "Hello world" };
    //        var category = _mapper.Map<Category>(updateCategoryModel);
    //        _unitOfWorkMock.Setup(unitOfWork => unitOfWork.Categories.Update(It.IsAny<Category>()));
    //        _unitOfWorkMock.Setup(unitOfWork => unitOfWork.Complete()).Returns(1);

    //        // Act
    //        _unitOfWorkMock.Object.Categories.Add(category);
    //        var affectedRows = _unitOfWorkMock.Object.Complete();

    //        //Assert
    //        Assert.IsType<Category>(category);
    //        Assert.True(affectedRows > 0);
    //    }


    //    [Fact]
    //    public void Get_Expression_ReturnsGetCategoryTitleModelList()
    //    {
    //        //Arrange
    //        // To meet the demand of a list of category, I created a global list.
    //         _unitOfWorkMock.Setup(unitOfWork => unitOfWork.Categories.GetTitles(c=>c.Id>0).Result).Returns(_categoryList);

    //        // Act
    //        var categories = _unitOfWorkMock.Object.Categories.GetTitles(c => c.Id >0);
    //        var categoryModelList = _mapper.Map<List<GetCategoryTitleModel>>(categories.Result);

    //        //Assert
    //        Assert.Equal(3, categoryModelList.Count);
    //        Assert.IsType<List<GetCategoryTitleModel>>(categoryModelList);
           
    //    }

    //    [Fact]
    //    public void Get_Category_ReturnsGetCategoryModel()
    //    {
    //        //Arrange
    //        // To meet the demand of a list of category, I created a global list.
    //         _unitOfWorkMock.Setup(
    //            unitOfWork => unitOfWork.Categories.Get(It.IsAny<Expression<Func<Category, bool>>>()).Result
    //            ).Returns(Task.FromResult(new Category() { Id = 1, Body = "asdasda", Title = "title", MetaTitle = "aaaaa", IsActive = true }).Result
    //            );


    //        // Act   
    //        var category = _unitOfWorkMock.Object.Categories.Get(c=>c.Id==1);
    //        var categoryModel = _mapper.Map<GetCategoryModel>(category.Result);

    //        //Assert
    //        Assert.IsType<GetCategoryModel>(categoryModel);
    //        Assert.NotNull(category);
    //        Assert.NotNull(categoryModel);
    //    }

    //    [Fact]
    //    public void Get_Expression_ReturnsGetCategoryModelList()
    //    {
    //        //Arrange
    //        // To meet the demand of a list of category, I created a global list.
    //        _unitOfWorkMock.Setup(unitOfWork => unitOfWork.Categories.GetAll(c => c.Id > 0).Result).Returns(_categoryList.Where(c=>c.Id>0).ToList());

    //        // Act

    //        var categories = _unitOfWorkMock.Object.Categories.GetAll(c => c.Id > 0);
    //        var categoryModelList = _mapper.Map<List<GetCategoryTitleModel>>(categories.Result);

    //        //Assert
    //        Assert.Equal(3, categoryModelList.Count);
    //        Assert.IsType<List<GetCategoryTitleModel>>(categoryModelList);
    //    }

    //}
}
