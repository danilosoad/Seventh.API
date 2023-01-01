using Seventh.Domain.Entities.Servers;

namespace Seventh.API.ViewModels.Servers.Adapter
{
    public static class ServerAdapter
    {
        public static Server ConvertToServer(this ServerViewModel viewModel)
        {
            return new Server(Guid.NewGuid(), viewModel.Name, viewModel.EnderecoIp, viewModel.PortaIp);
        }

        public static Server ConvertToServer(this ServerViewModel viewModel, Guid id)
        {
            return new Server(id, viewModel.Name, viewModel.EnderecoIp, viewModel.PortaIp);
        }
    }
}