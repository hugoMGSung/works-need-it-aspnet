using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;

namespace TodoListWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();
        TodoItemsCollection todoItems = new TodoItemsCollection();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CboIsComplete.Items.Add("true");
            CboIsComplete.Items.Add("false");

            client.BaseAddress = new Uri("https://localhost:7138/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            this.DgdTodoList.ItemsSource = todoItems;

            GetDatas();
        }

        private async void GetDatas()
        {
            try
            {
                var response = await client.GetAsync("api/TodoItems");
                response.EnsureSuccessStatusCode(); // 오류 코드를 던집니다.

                var items = await response.Content.ReadAsAsync<IEnumerable<TodoItem>>();
                todoItems.CopyFrom(items);
            }
            catch (Newtonsoft.Json.JsonException jEx)
            {
                // 이 예외는 요청 본문을 역직렬화 할 때, 문제가 발생했음을 나타냅니다.
                MessageBox.Show(jEx.Message);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }
        }

        private async void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            BtnInsert.IsEnabled = false;

            try
            {
                var item = new TodoItem()
                {
                    Id = 0,
                    Name = TxtName.Text,
                    IsComplete = CboIsComplete.SelectedValue.ToString(),
                };
                var response = await client.PostAsJsonAsync("api/TodoItems", item);
                response.EnsureSuccessStatusCode(); // 오류 코드를 던집니다.

                //todoItems.Add(item);
                GetDatas();

                TxtId.Text = TxtName.Text = string.Empty;
                CboIsComplete.SelectedIndex = 0;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Price must be a number");
            }
            finally
            {
                BtnInsert.IsEnabled = true;
            }
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            BtnDelete.IsEnabled = false;

            try
            {
                var id = TxtId.Text;
                var response = await client.DeleteAsync($"api/TodoItems/{id}");
                response.EnsureSuccessStatusCode(); // 오류 코드를 던집니다.

                GetDatas();

                TxtId.Text = TxtName.Text = string.Empty;
                CboIsComplete.SelectedIndex = 0;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Price must be a number");
            }
            finally
            {
                BtnDelete.IsEnabled = true;
            }
        }
    }
}
