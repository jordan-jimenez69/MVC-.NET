using Microsoft.AspNetCore.Identity;

namespace MVC.Data
{
    public static class RoleInitializer
    {
        public static async Task InitializeRoles(IServiceProvider serviceProvider)
        {
            // Obtenez l'instance de RoleManager depuis le service provider
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roles = { "Teacher", "Student" };

            foreach (var role in roles)
            {
                // Vérifier si le rôle existe déjà
                if (!await roleManager.RoleExistsAsync(role))
                {
                    // Si le rôle n'existe pas, le créer
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
