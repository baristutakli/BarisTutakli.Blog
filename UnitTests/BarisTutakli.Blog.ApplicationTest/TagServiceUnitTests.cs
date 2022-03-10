using AutoMapper;
using BarisTutakli.Blog.Application.Models.TagModels;
using BarisTutakli.Blog.Application.Tools.MappingProfiles;
using BarisTutakli.Blog.Domain.Entities;
using BarisTutakli.Blog.DomainServices.Interfaces;
using Blog.Application.Concrete;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BarisTutakli.Blog.ApplicationTest
{
    public class TagServiceUnitTests
    {
        Mock<IUnitOfWork> _unitOfWorkMock;
        TagService _tagService;

        IMapper _mapper;
        List<Tag> _tagList = new List<Tag>() {
        new Tag() { Id = 1, Body = "fffffffffffffffa", Title = "title", MetaTitle = "aaaaa", IsActive = true},
                new Tag() { Id = 2, Body = "aaaaaaaaaaaaaa", Title = "title", MetaTitle = "aaaaa", IsActive = true},
                new Tag() { Id = 3, Body = "asasasaa", Title = "title", MetaTitle = "aaaaa", IsActive = true}
        };

        public TagServiceUnitTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TagMappingProfile());
            });
            _mapper = mappingConfig.CreateMapper();


            _tagService = new TagService(_unitOfWorkMock.Object, _mapper);
        }

        [Fact]
        public void Add_Tag_ReturnsBoolean()
        {
            //Arrange
            CreateTagModel createTagModel = new CreateTagModel() { Body = "asdasda", MetaTitle = "c#", Title = "Hello world" };
            var tag = _mapper.Map<Tag>(createTagModel);
            _unitOfWorkMock.Setup(unitOfWork => unitOfWork.Tags.Add(It.IsAny<Tag>()));
            _unitOfWorkMock.Setup(unitOfWork => unitOfWork.Complete()).Returns(1);

            // Act

            _unitOfWorkMock.Object.Tags.Add(tag);
            var affectedRows = _unitOfWorkMock.Object.Complete();

            //Assert
            Assert.IsType<Tag>(tag);
            Assert.True(affectedRows > 0);
        }

        [Fact]
        public void Update_Tag_ReturnsBoolean()
        {
            //Arrange
            UpdateTagModel updateTagModel = new UpdateTagModel() { Body = "asdasda", MetaTitle = "c#", Title = "Hello world" };
            var tag = _mapper.Map<Tag>(updateTagModel);
            _unitOfWorkMock.Setup(unitOfWork => unitOfWork.Tags.Update(It.IsAny<Tag>()));
            _unitOfWorkMock.Setup(unitOfWork => unitOfWork.Complete()).Returns(1);

            // Act
            _unitOfWorkMock.Object.Tags.Add(tag);
            var affectedRows = _unitOfWorkMock.Object.Complete();

            //Assert
            Assert.IsType<Tag>(tag);
            Assert.True(affectedRows > 0);
        }



        [Fact]
        public void Get_Tag_ReturnsGetTagModel()
        {
            //Arrange
            // To meet the demand of a list of tag, I created a global list.
            _unitOfWorkMock.Setup(
               unitOfWork => unitOfWork.Tags.Get(It.IsAny<Expression<Func<Tag, bool>>>()).Result
               ).Returns(Task.FromResult(new Tag() { Id = 1, Body = "asdasda", Title = "title", MetaTitle = "aaaaa", IsActive = true }).Result
               );


            // Act   
            var tag = _unitOfWorkMock.Object.Tags.Get(c => c.Id == 1);
            var tagModel = _mapper.Map<GetTagModel>(tag.Result);

            //Assert
            Assert.IsType<GetTagModel>(tagModel);
            Assert.NotNull(tag);
            Assert.NotNull(tagModel);
        }

        [Fact]
        public void Get_Expression_ReturnsGetTagModelList()
        {
            //Arrange
            // To meet the demand of a list of tag, I created a global list.
            _unitOfWorkMock.Setup(unitOfWork => unitOfWork.Tags.GetAll(c => c.Id > 0).Result).Returns(_tagList.Where(c => c.Id > 0).ToList());

            // Act

            var tags = _unitOfWorkMock.Object.Tags.GetAll(c => c.Id > 0);
            var tagModelList = _mapper.Map<List<GetTagTitleModel>>(tags.Result);

            //Assert
            Assert.Equal(3, tagModelList.Count);
            Assert.IsType<List<GetTagTitleModel>>(tagModelList);
        }
    }
}
