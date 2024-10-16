using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Data;
using Data.Models;
using TodoApi.Data.Models;
using TodoApi.Data.Paging;
using TodoApi.Data.ViewModels;
using TodoApi.Exceptions;

namespace TodoApi.Data.Services
{
    public class PublisherService
    {
        private AppDbContext _context;

        public PublisherService(AppDbContext context)
        {
            _context = context;
        }

        public List<Publisher> GetAllPublishers(string sortBy , string searchString , int? pageNumber){
            var allPublishers = _context.Publishers.ToList();
            //sorting
            if(!string.IsNullOrEmpty(sortBy)){
                switch(sortBy){
                    case "name_desc":
                        allPublishers = allPublishers.OrderByDescending(n => n.Name).ToList();
                        break;
                    default:
                        break;
                }
            } 
            //filtering
            if(!string.IsNullOrEmpty(searchString)){
                allPublishers = allPublishers.Where(n=> n.Name.Contains(searchString , StringComparison.OrdinalIgnoreCase)).ToList();
            }
            //paging
            int pageSize = 5;
            allPublishers = PaginatedList<Publisher>.Create(allPublishers.AsQueryable(), pageNumber ?? 1, pageSize);
            return allPublishers;
        }
        
        public Publisher AddPublisher(PublisherVM publisher)
        {   if(StringStartsWithNumber(publisher.Name)) throw new PublisherNameException("Name starts with number", publisher.Name);
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };

            _context.Publishers.Add(_publisher);
            _context.SaveChanges();

            return _publisher;
        }

        public Publisher GetPublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);
            return _publisher;
        }

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId){
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId).Select(n => new PublisherWithBooksAndAuthorsVM(){
                Name = n.Name ,
                BooksAndAuthors = n.Books.Select(n => new BookAuthorVM(){
                    BookName = n.Title,
                    BookAndAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
                }).ToList()
            }).FirstOrDefault();
        
            return _publisherData;
        }

        public void DeletePublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);

            if(_publisher != null){
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }else{
                throw new Exception($"The publisher with id:{id} doesn't exist");
            }
        }

        private bool StringStartsWithNumber(string name){
            return Regex.IsMatch(name, @"^\d");
        }
    }
}