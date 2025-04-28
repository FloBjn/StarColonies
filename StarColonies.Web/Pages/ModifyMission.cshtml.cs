using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.Mappers;

namespace StarColonies.Web.Pages;

    public class ModifyMission : PageModel
    {
        public IList<Enemy> Enemies { get; set; }
        public Mission Mission { get; set; }
        
        public IList<Enemy> EnemyInMission { get; set; }

        [BindProperty]
        public InputModel InputModelInfos { get; set; }
        private IEnemyRepository _enemyRepository;
        private IMissionRepository _missionRepository;

        public ModifyMission(IEnemyRepository enemyRepository, IMissionRepository missionRepository)
        {
            _enemyRepository = enemyRepository;
            _missionRepository = missionRepository;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // Récupérer tous les ennemis de la base de données
            Console.WriteLine(id);
            Enemies = await _enemyRepository.GetAllEnemyAsync();
            Mission = await _missionRepository.GetByIdAsync(id);
            EnemyInMission = Mission.MissionEnemies;

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
            var mId = HttpContext.Session.GetString("MissionId");
            Enemies = await _enemyRepository.GetAllEnemyAsync();
            if (mId != null)
            {
                Mission = await _missionRepository.GetByIdAsync(mId);
                EnemyInMission = Mission.MissionEnemies;
            }
            
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

            await _missionRepository.UpdateMissionNameAsync(mission);
            await _missionRepository.UpdateMissionEnemiesAsync(mission);

            // Rediriger vers une autre page (par exemple, la liste des missions)
            return RedirectToPage("/Missions");
        }
    }


