using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SymptomsLibrary.Application.Interfaces;
using SymptomsLibrary.Presentation.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SymptomsLibrary.Test;

[TestClass]
public class DiseaseTest
{
    [TestInitialize]
    public async Task Initialize() => await Task.CompletedTask;

    [TestMethod]
    public async Task ShouldRegisterDisease()
    {
        // 1 - arrange 
        var name = "Covid 19";
        var payload = new Application.ViewModels.DiseaseRequestViewModel(name)
            .AddSymptom(new Application.ViewModels.DiseaseRequestViewModel.SymptomRequest("Fever"))
            .AddSymptom(new Application.ViewModels.DiseaseRequestViewModel.SymptomRequest("Headache"));

        var mockService = new Mock<IDiseaseService>();
        mockService.Setup(x => x.RegisterDiseaseAsync(payload))
            .ReturnsAsync(new Application.ViewModels.DiseaseResponseViewModel(1, name));

        var controller = new DiseaseController(mockService.Object);


        // 2 - act
        ActionResult actionResult = await controller.RegisterDiseaseAsync(payload);
        var contentResult = new OkObjectResult(actionResult);

        var result = contentResult.Value as ObjectResult;
        var response = result?.Value as Application.ViewModels.DiseaseResponseViewModel;


        // 3 - validation
        Assert.IsNotNull(contentResult);
        Assert.AreEqual(contentResult.StatusCode, 200);
        Assert.AreEqual(name, response?.Name);
    }

    [TestMethod]
    public async Task ShouldNotRegisterDisease()
    {
        // 1 - arrange 
        var name = "Covid 19";
        var payload = new Application.ViewModels.DiseaseRequestViewModel(name);

        var mockService = new Mock<IDiseaseService>();
        mockService.Setup(x => x.RegisterDiseaseAsync(payload))
            .ReturnsAsync(new Application.ViewModels.DiseaseResponseViewModel(1, name));

        var controller = new DiseaseController(mockService.Object);


        // 2 - act
        ActionResult actionResult = await controller.RegisterDiseaseAsync(payload);
        var contentResult = new OkObjectResult(actionResult);

        var result = contentResult.Value as ObjectResult;
        var response = result?.Value as Application.ViewModels.DiseaseResponseViewModel;


        // 3 - validation
        Assert.IsNotNull(contentResult);
        Assert.AreEqual(result?.StatusCode, 400);
        Assert.IsNull(response);
    }

    [TestMethod]
    public async Task ShouldGetAllDiseases()
    {
        // 1 - arrange 
        var mockService = new Mock<IDiseaseService>();
        mockService.Setup(x => x.GetDiseasesAsync())
            .ReturnsAsync(new List<Application.ViewModels.DiseaseListResponseViewModel>());

        var controller = new DiseaseController(mockService.Object);


        // 2 - act
        ActionResult<List<Application.ViewModels.DiseaseResponseViewModel>> actionResult = await controller.GetDiseasesAsync();
        var contentResult = new OkObjectResult(actionResult);
        var result = contentResult.Value as ObjectResult;
        var response = result?.Value as List<Application.ViewModels.DiseaseListResponseViewModel>;


        // 3 - validation
        Assert.IsNotNull(contentResult);
        Assert.AreEqual(contentResult.StatusCode, 200);
        //Assert.IsTrue(response?.Count == 1);
    }
}
