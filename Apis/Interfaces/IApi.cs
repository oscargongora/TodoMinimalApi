using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using TodoMinimalApi.Models;

namespace TodoMinimalApi.Apis.Interfaces;

public interface IApi
{
    void Register(WebApplication app);
}