//add class LogsService
using System;   
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System.Net;
using TodoApi.Exceptions;
using TodoApi.Data.Models;
using Data;

namespace TodoApi.Data.Services
{
    public class LogsService
    {
     private AppDbContext _context;

     public LogsService(AppDbContext context)
     {
         _context = context;
     }
     
     public List<Log> GetAllLogsFromDb(){
         return _context.Logs.ToList();
     }
    }
}