using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;

namespace EssentialMAUIUIKit
{
    public class AddressViewModel
    {
        public ObservableCollection<Address>? AddressDetails { get; set; }

        public ICommand EditAddressCommand { get; }

        public ICommand DeleteAddressCommand { get; }

        public ICommand AddAddressCommand { get; }

        public AddressViewModel()
        {
            EditAddressCommand = new Command<Address>(OnEditAddress);
            DeleteAddressCommand = new Command<Address>(OnDeleteAddress);
            AddAddressCommand = new Command(OnAddAddress);
            LoadData();
        }

        private void OnEditAddress(Address? address)
        {
            // Hook for the host application to launch the edit-address flow.
            // Intentionally left empty in the UI Kit sample.
        }

        private void OnDeleteAddress(Address? address)
        {
            if (address != null && AddressDetails != null)
            {
                AddressDetails.Remove(address);
            }
        }

        private void OnAddAddress()
        {
            // Hook for the host application to launch the add-address flow.
            // Intentionally left empty in the UI Kit sample.
        }

        private void LoadData()
        {
            string jsonData = @"
        {
            ""addressDetails"": [
                {
                    ""name"": ""John Doe"",
                    ""addressType"": ""Home"",
                    ""location"": ""114 Ridge St NW, Hudson, NC 28638"",
                    ""contactNumber"": ""(828) 228-2882""
                },
                {
                    ""name"": ""Diana Steve"",
                    ""addressType"": ""Work"",
                    ""location"": ""100 S 4th St, Bloomfield, NM 87413"",
                    ""contactNumber"": ""(828) 295-1271""
                },
                {
                    ""name"": ""Williams"",
                    ""addressType"": ""Home"",
                    ""location"": ""1234 Elm Street Springfield, UK"",
                    ""contactNumber"": ""(828) 657-8668""
                },
                {
                    ""name"": ""Marry John"",
                    ""addressType"": ""Work"",
                    ""location"": ""112  5th, Freedom street, London"",
                    ""contactNumber"": ""(828) 767-0987""
                }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var addressRoot = JsonSerializer.Deserialize<AddressRoot>(jsonData, options);
            if (addressRoot?.AddressDetails == null)
            {
                return;
            }

            AddressDetails = new ObservableCollection<Address>(addressRoot.AddressDetails);
        }
    }

    public class Address
    {
        public string? Name { get; set; }
        public string? AddressType { get; set; }
        public string? Location { get; set; }
        public string? ContactNumber { get; set; }
    }

    public class AddressRoot
    {
        public List<Address>? AddressDetails { get; set; }
    }

}
