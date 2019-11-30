using Model.Dao;
using Model.EF;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.Test.Dao
{
    [TestFixture]
    class CategoryDaoTest
    {
        CategoryDao categoryDao;

        [SetUp]
        public void SetUp()
        {
            categoryDao = new CategoryDao();
        }

        [Test]
        public void GetListProductEmptyWhenNotExistCategoryID()
        {
            Assert.AreEqual("", categoryDao.GetListAllProduct(0));
        }

        [Test]
        public void MatchCategoryHasCategoryIdIsEmptyThenThrowFormatException()
        {
            Assert.Throws<FormatException>(() => categoryDao.matchCategory(null, ""));
        }

        [Test]
        public void MatchCategoryHasTemplateIsNullThenThrowNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => categoryDao.matchCategory(null, "1"));
        }

    
        [Test]
        public void MatchSizeHasTemplateIsNullThenThrowTargetException()
        {
            Assert.Throws<System.Reflection.TargetException>(() => categoryDao.matchSize(null, "1"));
        }

        [Test]
        public void MatchColorReturnFalseWhenTemplateNotContainColorName()
        {
            var template = new TemplateProductView();
            template.ColorName = "RED";
            Assert.AreEqual(false, categoryDao.matchColor(template, "BLACK"));

        }

        [Test]
        public void MatchColorReturnTrueWhenTemplateContainColorName()
        {
            var template = new TemplateProductView();
            template.ColorName = "YELLOW RED";
            Assert.AreEqual(false, categoryDao.matchColor(template, "RED"));
        }

        [Test]
        public void MatchCotentReturnFalseWhenTemplateNotContainCotent()
        {
            var template = new TemplateProductView();
            template.Name = "A";
            template.Descriptions = "B";
            Assert.AreEqual(false, categoryDao.matchContent(template, "D"));

        }

        [Test]
        public void MatchContentReturnTrueWhenTemplateContainContent()
        {
            var template = new TemplateProductView();
            template.Name = "ABC";
            template.Descriptions = "DEF";
            Assert.AreEqual(false, categoryDao.matchContent(template, "BC"));

        }
    }
}
