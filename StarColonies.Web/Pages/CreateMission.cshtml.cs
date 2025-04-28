using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.Mappers;

namespace StarColonies.Web.Pages;

    public class CreateMissionModel : PageModel
    {
        public IList<Enemy> Enemies { get; set; }

        [BindProperty]
        public InputModel InputModelInfos { get; set; }
        private IEnemyRepository _enemyRepository;
        private IMissionRepository _missionRepository;

        public CreateMissionModel(IEnemyRepository enemyRepository, IMissionRepository missionRepository)
        {
            _enemyRepository = enemyRepository;
            _missionRepository = missionRepository;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // Récupérer tous les ennemis de la base de données
            Enemies = await _enemyRepository.GetAllEnemyAsync();
            
            return Page();
        }

        // Le modèle pour la soumission du formulaire
        public class InputModel
        {
            public string MissionName { get; set; }

            // Liste d'ennemis sélectionnés par l'utilisateur (leurs IDs)
            public List<string> SelectedEnemiesId { get; set; } = new List<string>();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Enemies = await _enemyRepository.GetAllEnemyAsync();
            if (!TryValidateModel(InputModelInfos))
            {
                Console.WriteLine("Invalid input");
                return Page();
            }

            // Vous pouvez maintenant traiter les ennemis sélectionnés
            var selectedEnemies = Enemies
                .Where(e => InputModelInfos.SelectedEnemiesId.Contains(e.EnemyId))
                .ToList();

            foreach (var enemy in selectedEnemies)
            {
                Console.WriteLine($"ennemy : {enemy.Name}");
            }
            // Enregistrer la mission avec les ennemis sélectionnés dans la base de données
            var mission = new Mission
            {
                MissionId = Guid.NewGuid().ToString(),  // Générer un ID unique
                Name = InputModelInfos.MissionName,
                MissionEnemies = selectedEnemies
            };

            await _missionRepository.AddMissionAsync(mission);

            // Rediriger vers une autre page (par exemple, la liste des missions)
            return RedirectToPage("/Missions");
        }
    }


