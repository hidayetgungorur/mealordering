using System.Net.Http.Json;
using MealOrdering.Client.Pages.Users;
using MealOrdering.Client.Utils;
using MealOrdering.Shared.CustomExceptions;
using MealOrdering.Shared.Dto;
using MealOrdering.Shared.ResponseModels;
using Microsoft.AspNetCore.Components;


namespace MealOrdering.Client.Pages.PageProcess
{
    public class UserListProcess :ComponentBase
	{
        [Inject]
        public HttpClient Client { get; set; }

        [Inject]
        ModalManager ModalManager { get; set; }

        protected List<UserDto> userList = new List<UserDto>();

        protected async override Task OnInitializedAsync()
        {
            await LoadList();
        }


        protected async Task LoadList()
        {
            try
            {

                userList= await Client.GetServiceResponseAsync<List<UserDto>>("api/User/Users",true);

                //var result = await Client.GetFromJsonAsync<ServiceResponse<List<UserDto>>>("api/User/Users");
                //if (result.Success)
                //    userList = result.Value;
            }
            catch (ApiException ex)
            {
                await ModalManager.ShowMessageAsync("ApiException", ex.Message);
            }
        }

    }
}

