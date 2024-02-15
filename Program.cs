var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<VirtualMachineQuery>(); 

var app = builder.Build();

app.MapGraphQL();

app.Run();

public class VirtualMachineQuery {
    List<VirtualMachine> createVirtualMachinesList() {
        List<VirtualMachine> virtualMachines = new List<VirtualMachine>();
        for (int i = 0; i < 100; i++) {
            virtualMachines.Add(new VirtualMachine {
                    Name = $"VM{i}",
                    Status = "Running"
                    });
        }
        return virtualMachines;
    }

    public VirtualMachine GetVirtualMachine() {
        return new VirtualMachine {
            Name = "VM1",
            Status = "Running"
        };
    }

    public List<VirtualMachine> GetVirtualMachines()
        => createVirtualMachinesList();

    public VirtualMachine GetVirtualMachineByName(string name){
        VirtualMachine ?vm = createVirtualMachinesList().FirstOrDefault(vm => vm.Name == name);
        if (vm == null)
        {
            throw new Exception("Not found:");
        }
        return vm;
    }
}

public class VirtualMachine
{
    public string Name { get; set; }
    public string Status { get; set; }
}
