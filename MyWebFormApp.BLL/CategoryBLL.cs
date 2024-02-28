using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;
using MyWebFormApp.BO;
using MyWebFormApp.DAL;
using MyWebFormApp.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace MyWebFormApp.BLL
{
    public class CategoryBLL : ICategoryBLL
    {
        private readonly ICategoryDAL _categoryDAL;
        public CategoryBLL()
        {
            _categoryDAL = new CategoryDAL();
        }

        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("CategoryID is required");
            }

            try
            {
                _categoryDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            List<CategoryDTO> listCategoriesDto = new List<CategoryDTO>();
            var categories = _categoryDAL.GetAll();
            foreach (var category in categories)
            {
                listCategoriesDto.Add(new CategoryDTO
                {
                    CategoryID = category.CategoryID,
                    CategoryName = category.CategoryName
                });
            }
            return listCategoriesDto;
        }

        public CategoryDTO GetById(int id)
        {
            CategoryDTO categoryDto = new CategoryDTO();
            var category = _categoryDAL.GetById(id);
            if (category != null)
            {
                categoryDto.CategoryID = category.CategoryID;
                categoryDto.CategoryName = category.CategoryName;
            }
            else
            {
                throw new ArgumentException($"Category {id} not found");
            }
            return categoryDto;
        }

        public IEnumerable<CategoryDTO> GetByName(string name)
        {
            var categories = _categoryDAL.GetByName(name);

            //mapping ke DTO
            List<CategoryDTO> listCategoriesDto = new List<CategoryDTO>();
            foreach (var category in categories)
            {
                listCategoriesDto.Add(new CategoryDTO
                {
                    CategoryID = category.CategoryID,
                    CategoryName = category.CategoryName
                });
            }
            return listCategoriesDto;
        }

        public int GetCountCategories(string name)
        {
            return _categoryDAL.GetCountCategories(name);
        }

        public IEnumerable<CategoryDTO> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            /*if (pageNumber <= 0)
            {
                throw new ArgumentException("PageNumber is required");
            }
            else if (pageSize <= 0)
            {
                throw new ArgumentException("PageSize is required");
            }*/

            List<CategoryDTO> listCategoriesDto = new List<CategoryDTO>();
            var categories = _categoryDAL.GetWithPaging(pageNumber, pageSize, name);
            foreach (var category in categories)
            {
                listCategoriesDto.Add(new CategoryDTO
                {
                    CategoryID = category.CategoryID,
                    CategoryName = category.CategoryName
                });
            }
            return listCategoriesDto;
        }

        public void Insert(CategoryCreateDTO entity)
        {
            if (string.IsNullOrEmpty(entity.CategoryName))
            {
                throw new ArgumentException("CategoryName is required");
            }
            else if (entity.CategoryName.Length > 50)
            {
                throw new ArgumentException("CategoryName max length is 50");
            }

            try
            {
                var newCategory = new Category
                {
                    CategoryName = entity.CategoryName
                };
                _categoryDAL.Insert(newCategory);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Update(CategoryUpdateDTO entity)
        {
            if (entity.CategoryID <= 0)
            {
                throw new ArgumentException("CategoryID is required");
            }
            else if (string.IsNullOrEmpty(entity.CategoryName))
            {
                throw new ArgumentException("CategoryName is required");
            }
            else if (entity.CategoryName.Length > 50)
            {
                throw new ArgumentException("CategoryName max length is 50");
            }

            try
            {
                var category = new Category
                {
                    CategoryID = entity.CategoryID,
                    CategoryName = entity.CategoryName
                };
                _categoryDAL.Update(category);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
