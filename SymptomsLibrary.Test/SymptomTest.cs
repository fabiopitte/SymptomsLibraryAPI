using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SymptomsLibrary.Application.Interfaces;
using SymptomsLibrary.Presentation.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SymptomsLibrary.Test;

[TestClass]
public class SymptomTest
{
    [TestInitialize]
    public async Task Initialize() => await Task.CompletedTask;

    [TestMethod]
    public async Task ShouldRegisterSymptom()
    {
        // 1 - arrange 
        var name = "Fever";
        var payload = new Application.ViewModels.SymptomRequestViewModel(name);

        var mockService = new Mock<ISymptomService>();
        mockService.Setup(x => x.RegisterSymptomAsync(payload))
            .ReturnsAsync(new Application.ViewModels.SymptomResponseViewModel(1, name));

        var controller = new SymptomController(mockService.Object);


        // 2 - act
        ActionResult actionResult = await controller.RegisterSymptomAsync(payload);
        var contentResult = new OkObjectResult(actionResult);

        var result = contentResult.Value as ObjectResult;
        var response = result?.Value as Application.ViewModels.SymptomResponseViewModel;


        // 3 - validation
        Assert.IsNotNull(contentResult);
        Assert.AreEqual(contentResult.StatusCode, 200);
        Assert.AreEqual(name, response?.Name);
    }

    [TestMethod]
    public async Task ShouldGetAllSymptoms()
    {
        // 1 - arrange 
        var mockService = new Mock<ISymptomService>();
        mockService.Setup(x => x.GetSymptomsAsync())
            .ReturnsAsync(new List<Application.ViewModels.SymptomResponseViewModel>());

        var controller = new SymptomController(mockService.Object);


        // 2 - act
        ActionResult<List<Application.ViewModels.SymptomResponseViewModel>> actionResult = await controller.GetSymptomsAsync();
        var contentResult = new OkObjectResult(actionResult);
        var result = contentResult.Value as ObjectResult;
        var response = result?.Value as List<Application.ViewModels.SymptomResponseViewModel>;


        // 3 - validation
        Assert.IsNotNull(contentResult);
        Assert.AreEqual(contentResult.StatusCode, 200);
    }
}
