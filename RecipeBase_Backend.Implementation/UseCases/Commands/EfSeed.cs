using Castle.Core;
using Mapster.Models;
using MapsterMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using RecipeBase_Backend.Application.UseCases.Commands;
using RecipeBase_Backend.DataAccess;
using RecipeBase_Backend.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.Internal.AsyncLock;
using static System.Formats.Asn1.AsnWriter;

namespace RecipeBase_Backend.Implementation.UseCases.Commands
{
    public class EfSeed : EfUseCase, ISeed
    {
        public EfSeed(AppDbContext dbContext)
            : base(dbContext)
        {

        }

        public int Id => 1;

        public string Name => "DB Seeder";

        public string Description => "Initial Database Seeder for EntityFramework";

        public void Execute()
        {
            if (this.DbContext.Images.Any())
            {
                return;
            }

            var images = new List<Image>
            {
                new Image { Path = "traditional_mexican_guacamole.jpg"},
                new Image { Path = "fully_loaded_deviled_eggs.jpg"},
                new Image { Path = "caprese_on_a_stick.jpg"},
                new Image { Path = "fried_mozzarela_cheese_sticks.jfif"},
                new Image { Path = "world's_best_lasagna.jfif"},
                new Image { Path = "best_hamburger_ever.jfif"},
                new Image { Path = "chicken_parmesan.jfif"},
                new Image { Path = "easy_meatloaf.jfif"},
                new Image { Path = "easy_fried_rice.jfif"},
                new Image { Path = "indian_chicken_curry_(murgh_ kari).jfif"},
                new Image { Path = "potato_salad.jfif"},
                new Image { Path = "marinated_cucumber,_onion,_and_tomato_salad.jfif"},
                new Image { Path = "awesome_pasta_salad.jfif"},
                new Image { Path = "mom's_cucumber_salad.png"},
                new Image { Path = "best_brownies.jfif"},
                new Image { Path = "best_chocolate_chip_cookies.jfif"},
                new Image { Path = "edible_cookie_dough.jfif"},
                new Image { Path = "the_best_lemon_bars.jfif"},
                new Image { Path = "how_to_make_vanilla_ice_cream.png"},
                new Image { Path = "old-fashioned_lemonade.jfif"},
                new Image { Path = "parker's_famous_margaritas.jpg"},
                new Image { Path = "best_strawberry_daiquiri.jfif"},
                new Image { Path = "strawberry_mojito.jpg"},
                new Image { Path = "classic_old_fashioned.jfif"},
                new Image { Path = "classic_bloody_mary.jfif"},
                new Image { Path = "naan.jfif"},
                new Image { Path = "belle's_hamburger_buns.jfif"},
                new Image { Path = "banana_chocolate_chip_bread.jfif"},
                new Image { Path = "simple_whole_wheat_bread.jfif"},
                new Image { Path = "brioche.jfif"},
                new Image { Path = "traditional_layered_french_croissant.jpg"}
            };

            var categories = new List<Category>
            {
                new Category{ Name = "Appetizers"},
                new Category{ Name = "Main dishes"},
                new Category{ Name = "Salads"},
                new Category{ Name = "Desserts"},
                new Category{ Name = "Pastries and bread"},
                new Category{ Name = "Drinks"}
            };

            var users = new List<User>
            {
                new User{Email = "recipebase@gmail.com", Username = "RecipeBase", FullName = "Recipe Base", Password = "$2a$11$swPEMu30P.y7ULFFig0TLeiEuJ8FHvsHxjdTZUSAdlxmPQ9xBuSl2"},
                new User{Email = "pera@gmail.com", Username = "Pera", FullName = "Petar Peric", Password = "$2a$11$swPEMu30P.y7ULFFig0TLeiEuJ8FHvsHxjdTZUSAdlxmPQ9xBuSl2"},
                new User{Email = "admin@gmail.com", Username = "Admin", FullName = "Admin User", Password = "$2a$11$swPEMu30P.y7ULFFig0TLeiEuJ8FHvsHxjdTZUSAdlxmPQ9xBuSl2"}
            };

            var recipes = new List<Recipe>
            {
                new Recipe{Title ="Traditional Mexican Guacamole", Category = categories.First(), Image = images.First(), PrepTime = "10 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient{Value = "2 avocados, peeled and pitted" },
                        new Ingredient{Value = "1 cup chopped tomatoes" },
                        new Ingredient{Value = "1/4 cup chopped onion" },
                        new Ingredient{Value = "1/4 cup chopped cilantro" },
                        new Ingredient{Value = "2 tablespoons lemon juice" },
                        new Ingredient{Value = "1 jalapeno pepper, seeded and minced (Optional)" },
                        new Ingredient{Value = "salt and ground black pepper to taste" }
                    },
                    Directions = new List<Direction>
                    {
                        new Direction{ StepNumber = 1, Step = "Mash avocados in a bowl until creamy."},
                        new Direction{ StepNumber = 2, Step = "Mix tomatoes, onion, cilantro, lemon juice, and jalapeno pepper into mashed avocado until well combined; season with salt and black pepper."},
                    }
                },
                new Recipe{Title ="Fully Loaded Deviled Eggs", Category = categories.First(), Image = images.ElementAt(1), PrepTime = "2 hrs 25 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient{Value = "12 eggs" },
                        new Ingredient{Value = "1 teaspoon vegetable oil" },
                        new Ingredient{Value = "1 small onion, chopped"},
                        new Ingredient{Value = "1/4 cup sour cream"},
                        new Ingredient{Value = "2 tablespoons mayonnaise"},
                        new Ingredient{Value = "1 tablespoon ranch dressing, or to taste"},
                        new Ingredient{Value = "1 1/2 teaspoons Dijon mustard"},
                        new Ingredient{Value = "1/2 teaspoon garlic powder"},
                        new Ingredient{Value = "1/2 pinch onion powder"},
                        new Ingredient{Value = "1/8 teaspoon lemon pepper seasoning"},
                        new Ingredient{Value = "1 tablespoon bacon bits, or to taste"},
                        new Ingredient{Value = "1 cup finely shredded sharp Cheddar cheese"},
                        new Ingredient{Value = "¼ teaspoon paprika, or as needed"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction{ StepNumber = 1, Step = "Place eggs into a large pot and cover with lightly salted water. Bring to a boil and reduce heat to medium; boil eggs for 10 to 12 minutes. Drain the boiling water and fill pot with cold water. After 2 to 3 minutes, pour off water and replace with more cold water. Repeat until eggs are fully chilled, 10 to 15 minutes. Peel eggs."},
                        new Direction{ StepNumber = 2, Step = "Heat vegetable oil in a small skillet over medium heat and cook and stir onion until translucent, about 5 minutes. Remove from heat and let cool."},
                        new Direction{ StepNumber = 3, Step = "Slice eggs in half lengthwise and scoop yolks into a bowl; transfer egg white halves to a plate. Mash egg yolks with a fork; stir in sour cream, mayonnaise, ranch dressing, Dijon mustard, garlic powder, onion powder, and lemon pepper seasoning until yolk mixture is smooth. Stir in sauteed onions, bacon bits and Cheddar cheese."},
                        new Direction{ StepNumber = 4, Step = "Generously fill egg halves with filling and sprinkle each deviled egg with paprika. Refrigerate until chilled before serving."}
                    }
                },
                new Recipe{Title ="Caprese on a Stick", Category = categories.First(), Image = images.ElementAt(2), PrepTime = "15 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient{Value = "1 pint cherry tomatoes, halved" },
                        new Ingredient{Value = "1 (.6 ounce) package fresh basil leaves" },
                        new Ingredient{Value = "1 (16 ounce) package small fresh mozzarella balls" },
                        new Ingredient{Value = "toothpicks" },
                        new Ingredient{Value = "3 tablespoons olive oil" },
                        new Ingredient{Value = "salt and pepper to taste" }
                    },
                    Directions = new List<Direction>
                    {
                        new Direction{Step = "Thread a tomato half, a small piece of basil leaf, and a mozzarella ball onto toothpicks until all ingredients are used. Drizzle the olive oil over the tomato, cheese and basil, leaving the end of the toothpick clean. Sprinkle with salt and pepper. Serve immediately."}                        
                    }
                },
                new Recipe{Title ="Fried Mozzarella Cheese Sticks", Category = categories.First(), Image = images.ElementAt(3), PrepTime = "25 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient{Value = "2 large eggs, beaten" },
                        new Ingredient{Value = "1/4 cup water"},
                        new Ingredient{Value = "1 1/2 cups Italian seasoned bread crumbs"},
                        new Ingredient{Value = "1/2 teaspoon garlic salt"},
                        new Ingredient{Value = "2/3 cup all-purpose flour"},
                        new Ingredient{Value = "1/3 cup cornstarch"},
                        new Ingredient{Value = "2 cups oil for frying, or as needed"},
                        new Ingredient{Value = "1 (16 ounce) package mozzarella cheese sticks"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction{ StepNumber = 1, Step = "Whisk water and eggs together in a small bowl. Mix bread crumbs and garlic salt together in a medium bowl. Blend flour and cornstarch together in a third bowl."},
                        new Direction{ StepNumber = 2, Step = "Heat oil to 365 degrees F (185 degrees C) in a large, heavy saucepan."},
                        new Direction{ StepNumber = 3, Step = "Dredge a mozzarella stick in flour; shake off excess. Dip into egg mixture. Lift up so excess egg drips back in the bowl. Press into bread crumbs to coat. Place breaded mozzarella stick on a plate or wire rack. Repeat with remaining mozzarella sticks."},
                        new Direction{ StepNumber = 4, Step = "Use a spider spoon or a pair of tongs to lower 3 to 4 mozzarella sticks into the hot oil. Fry until golden brown, about 30 seconds. Remove from heat and drain on paper towels. Repeat to fry remaining mozzarella sticks."}
                    }
                },
                new Recipe{Title ="World's Best Lasagna", Category = categories.ElementAt(1), Image = images.ElementAt(4), PrepTime = "3 hrs 15 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                       new Ingredient{ Value = "1 pound sweet Italian sausage" },
                       new Ingredient{ Value = "3/4 pound lean ground beef"},
                       new Ingredient{ Value = "1/2 cup minced onion"},
                       new Ingredient{ Value = "2 cloves garlic, crushed"},
                       new Ingredient{ Value = "1 (28 ounce) can crushed tomatoes"},
                       new Ingredient{ Value = "2 (6 ounce) cans tomato paste"},
                       new Ingredient{ Value = "2 (6.5 ounce) cans canned tomato sauce"},
                       new Ingredient{ Value = "1/2 cup water"},
                       new Ingredient{ Value = "2 tablespoons white sugar"},
                       new Ingredient{ Value = "1 1/2 teaspoons dried basil leaves"},
                       new Ingredient{ Value = "1/2 teaspoon fennel seeds"},
                       new Ingredient{ Value = "1 teaspoon Italian seasoning"},
                       new Ingredient{ Value = "1 1/2 teaspoons salt, divided, or to taste"},
                       new Ingredient{ Value = "1/4 teaspoon ground black pepper"},
                       new Ingredient{ Value = "4 tablespoons chopped fresh parsley"},
                       new Ingredient{ Value = "12 lasagna noodles"},
                       new Ingredient{ Value = "16 ounces ricotta cheese"},
                       new Ingredient{ Value = "1 egg"},
                       new Ingredient{ Value = "3/4 pound mozzarella cheese, sliced"},
                       new Ingredient{ Value = "3/4 cup grated Parmesan cheese"}
                    },
                    Directions = new List<Direction>
                    {
                       new Direction{ StepNumber = 1, Step = "In a Dutch oven, cook sausage, ground beef, onion, and garlic over medium heat until well browned. Stir in crushed tomatoes, tomato paste, tomato sauce, and water. Season with sugar, basil, fennel seeds, Italian seasoning, 1 teaspoon salt, pepper, and 2 tablespoons parsley. Simmer, covered, for about 1 1 / 2 hours, stirring occasionally." },
                       new Direction{ StepNumber = 2, Step = "Bring a large pot of lightly salted water to a boil.Cook lasagna noodles in boiling water for 8 to 10 minutes.Drain noodles, and rinse with cold water.In a mixing bowl, combine ricotta cheese with egg, remaining parsley, and 1 / 2 teaspoon salt." },
                       new Direction{ StepNumber = 3, Step = "Preheat oven to 375 degrees F(190 degrees C)." },
                       new Direction{ StepNumber = 4, Step = "To assemble, spread 1 1 / 2 cups of meat sauce in the bottom of a 9x13 - inch baking dish.Arrange 6 noodles lengthwise over meat sauce.Spread with one half of the ricotta cheese mixture.Top with a third of mozzarella cheese slices.Spoon 1 1 / 2 cups meat sauce over mozzarella, and sprinkle with 1 / 4 cup Parmesan cheese.Repeat layers, and top with remaining mozzarella and Parmesan cheese.Cover with foil: to prevent sticking, either spray foil with cooking spray, or make sure the foil does not touch the cheese." },
                       new Direction{ StepNumber = 5, Step = "Bake in preheated oven for 25 minutes.Remove foil, and bake an additional 25 minutes.Cool for 15 minutes before serving." }
                    }
                },
                new Recipe{Title ="Best Hamburger Ever", Category = categories.ElementAt(1), Image = images.ElementAt(5), PrepTime = "20 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient{ Value = "1 1/2 pounds lean ground beef" },
                        new Ingredient{ Value = "1/2 onion, finely chopped" },
                        new Ingredient{ Value = "1/2 cup shredded Colby Jack or Cheddar cheese" },
                        new Ingredient{ Value = "1 (1 ounce) envelope dry onion soup mix" },
                        new Ingredient{ Value = "1 egg" },
                        new Ingredient{ Value = "1 clove garlic, minced" },
                        new Ingredient{ Value = "1 tablespoon garlic powder" },
                        new Ingredient{ Value = "1 teaspoon soy sauce" },
                        new Ingredient{ Value = "1 teaspoon Worcestershire sauce" },
                        new Ingredient{ Value = "1 teaspoon dried parsley" },
                        new Ingredient{ Value = "1 teaspoon dried basil" },
                        new Ingredient{ Value = "1 teaspoon dried oregano" },
                        new Ingredient{ Value = "1/2 teaspoon crushed dried rosemary" },
                        new Ingredient{ Value = "salt and pepper to taste" }
                    },
                    Directions = new List<Direction>
                    {
                        new Direction{ StepNumber = 1, Step = "Preheat a grill on high heat." },
                        new Direction{ StepNumber = 2, Step = "Mix together ground beef, onion, cheese, onion soup mix, egg, garlic, garlic powder, soy sauce, Worcestershire sauce, parsley, basil, oregano, rosemary, salt, and pepper in a large bowl. Use your hands to form 4 patties." },
                        new Direction{ StepNumber = 3, Step = "Cook patties on the preheated grill until well-done, about 5 minutes per side." }
                    }
                },
                new Recipe{Title ="Chicken Parmesan", Category = categories.ElementAt(1), Image = images.ElementAt(6), PrepTime = "45 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient{ Value = "4 skinless, boneless chicken breast halves"},
                        new Ingredient{ Value = "salt and freshly ground black pepper to taste"},
                        new Ingredient{ Value = "2 large eggs"},
                        new Ingredient{ Value = "1 cup panko bread crumbs, or more as needed"},
                        new Ingredient{ Value = "3/4 cup grated Parmesan cheese, divided"},
                        new Ingredient{ Value = "2 tablespoons all-purpose flour, or more if needed"},
                        new Ingredient{ Value = "1/2 cup olive oil for frying, or as needed"},
                        new Ingredient{ Value = "1/2 cup prepared tomato sauce"},
                        new Ingredient{ Value = "1/4 cup fresh mozzarella, cut into small cubes"},
                        new Ingredient{ Value = "1/4 cup chopped fresh basil"},
                        new Ingredient{ Value = "1/2 cup grated provolone cheese"},
                        new Ingredient{ Value = "2 teaspoons olive oil"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction { StepNumber = 1, Step = "Preheat an oven to 450 degrees F (230 degrees C)." },
                        new Direction { StepNumber = 2, Step = "Place chicken breasts between two sheets of heavy plastic (resealable freezer bags work well) on a solid, level surface. Firmly pound chicken with the smooth side of a meat mallet to a thickness of 1/2-inch. Season chicken thoroughly with salt and pepper." },
                        new Direction { StepNumber = 3, Step = "Beat eggs in a shallow bowl and set aside." },
                        new Direction { StepNumber = 4, Step = "Mix bread crumbs and 1/2 cup Parmesan cheese in a separate bowl, set aside." },
                        new Direction { StepNumber = 5, Step = "Place flour in a sifter or strainer; sprinkle over chicken breasts, evenly coating both sides." },
                        new Direction { StepNumber = 6, Step = "Dip a flour-coated chicken breast in beaten eggs. Transfer breast to the bread crumb mixture, pressing crumbs into both sides.Repeat for each breast. Let chicken rest for 10 to 15 minutes." },
                        new Direction { StepNumber = 7, Step = "Heat 1 / 2 inch olive oil in a large skillet on medium - high heat until it begins to shimmer.Cook chicken in the hot oil until golden, about 2 minutes per side.The chicken will finish cooking in the oven." },
                        new Direction { StepNumber = 8, Step = "Transfer chicken to a baking dish.Top each breast with 2 tablespoons tomato sauce.Layer each chicken breast with equal amounts of mozzarella cheese, fresh basil, and provolone cheese.Sprinkle remaining Parmesan over top and drizzle each with 1 / 2 teaspoon olive oil." },
                        new Direction { StepNumber = 9, Step = "Bake in the preheated oven until cheese is browned and bubbly and chicken breasts are no longer pink in the center, 15 to 20 minutes.An instant - read thermometer inserted into the center should read at least 165 degrees F(74 degrees C)." }
                    }
                },
                new Recipe{Title ="Easy Meatloaf", Category = categories.ElementAt(1), Image = images.ElementAt(7), PrepTime = "1 hr 15 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Value = "1 1/2 pounds ground beef" }, 
                        new Ingredient { Value = "1 egg" },
                        new Ingredient { Value = "1 onion, chopped" },
                        new Ingredient { Value = "1 cup milk" },
                        new Ingredient { Value = "1 cup dried bread crumbs" },
                        new Ingredient { Value = "salt and pepper to taste" },
                        new Ingredient { Value = "2 tablespoons brown sugar" },
                        new Ingredient { Value = "2 tablespoons prepared mustard" },
                        new Ingredient { Value = "1/3 cup ketchup" }
                    },
                    Directions = new List<Direction>
                    {
                        new Direction { StepNumber = 1, Step = "Preheat oven to 350 degrees F (175 degrees C). " },
                        new Direction { StepNumber = 2, Step = "In a large bowl, combine the beef, egg, onion, milk and bread OR cracker crumbs. Season with salt and pepper to taste and place in a lightly greased 9x5-inch loaf pan, or form into a loaf and place in a lightly greased 9x13-inch baking dish." },
                        new Direction { StepNumber = 3, Step = "In a separate small bowl, combine the brown sugar, mustard and ketchup. Mix well and pour over the meatloaf." },
                        new Direction { StepNumber = 4, Step = "Bake at 350 degrees F (175 degrees C) for 1 hour." }
                    }
                },
                new Recipe{Title ="Easy Fried Rice", Category = categories.ElementAt(1), Image = images.ElementAt(8), PrepTime = "20 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Value = "2/3 cup chopped baby carrots" },
                        new Ingredient { Value = "1/2 cup frozen green peas"},
                        new Ingredient { Value = "2 tablespoons vegetable oil"},
                        new Ingredient { Value = "1 clove garlic, minced, or to taste (Optional)"},
                        new Ingredient { Value = "2 large eggs"},
                        new Ingredient { Value = "3 cups leftover cooked white rice"},
                        new Ingredient { Value = "1 tablespoon soy sauce, or more to taste"},
                        new Ingredient { Value = "2 teaspoons sesame oil, or to taste"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction { StepNumber = 1, Step = "Place carrots in a small saucepan and cover with water. Bring to a low boil and cook for 3 to 5 minutes.Stir in peas, then immediately drain in a colander." },
                        new Direction { StepNumber = 2, Step = "Heat a wok over high heat.Pour in vegetable oil, then stir in carrots, peas, and garlic; cook for about 30 seconds.Add eggs; stir quickly to scramble eggs with vegetables." },
                        new Direction { StepNumber = 3, Step = "Stir in cooked rice.Add soy sauce and toss rice to coat.Drizzle with sesame oil and toss again." }
                    }
                },
                new Recipe{Title ="Indian Chicken Curry (Murgh Kari)", Category = categories.ElementAt(1), Image = images.ElementAt(9), PrepTime = "1 hr", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Value = "2 pounds skinless, boneless chicken breast halves" },
                        new Ingredient { Value = "2 teaspoons salt"},
                        new Ingredient { Value = "1/2 cup cooking oil"},
                        new Ingredient { Value = "1 1/2 cups chopped onion"},
                        new Ingredient { Value = "1 tablespoon minced garlic"},
                        new Ingredient { Value = "1 1/2 teaspoons minced fresh ginger root"},
                        new Ingredient { Value = "1 tablespoon curry powder"},
                        new Ingredient { Value = "1 teaspoon ground cumin"},
                        new Ingredient { Value = "1 teaspoon ground turmeric"},
                        new Ingredient { Value = "1 teaspoon ground coriander"},
                        new Ingredient { Value = "1 teaspoon cayenne pepper"},
                        new Ingredient { Value = "1 tablespoon water"},
                        new Ingredient { Value = "1 (15 ounce) can crushed tomatoes"},
                        new Ingredient { Value = "1 cup plain yogurt"},
                        new Ingredient { Value = "1 tablespoon chopped fresh cilantro"},
                        new Ingredient { Value = "1 teaspoon salt"},
                        new Ingredient { Value = "1/2 cup water"},
                        new Ingredient { Value = "1 teaspoon garam masala"},
                        new Ingredient { Value = "1 tablespoon chopped fresh cilantro"},
                        new Ingredient { Value = "1 tablespoon fresh lemon juice"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction{StepNumber = 1, Step = "Sprinkle the chicken breasts with 2 teaspoons salt."},
                        new Direction{StepNumber = 2, Step = "Heat oil in a large skillet over high heat; partially cook the chicken in the hot oil in batches until completely browned on all sides.Transfer browned chicken breasts to a plate and set aside."},
                        new Direction{StepNumber = 3, Step = "Reduce the heat to medium and add onion, garlic, and ginger to the oil remaining in the skillet. Cook and stir until onion turns soft and translucent, 5 to 8 minutes.Stir curry powder, cumin, turmeric, coriander, cayenne, and 1 tablespoon of water into the onion mixture; allow to heat together for about 1 minute while stirring.Add tomatoes, yogurt, 1 tablespoon chopped cilantro, and 1 teaspoon salt to the mixture; stir to combine."},
                        new Direction{StepNumber = 4, Step = "Return chicken breast to the skillet along with any juices on the plate. Pour in 1 / 2 cup water and bring to a boil, turning the chicken to coat with the sauce. Sprinkle garam masala and 1 tablespoon cilantro over the chicken."},
                        new Direction{StepNumber = 5, Step = "Cover the skillet and simmer until chicken breasts are no longer pink in the center and the juices run clear, about 20 minutes.An instant-read thermometer inserted into the center should read at least 165 degrees F(74 degrees C). Drizzle with lemon juice to serve."}
                    }
                },
                new Recipe{Title ="Potato Salad", Category = categories.ElementAt(2), Image = images.ElementAt(10), PrepTime = "6 hrs 30 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Value = "5 pounds red potatoes, chopped" },
                        new Ingredient { Value = "3 cups mayonnaise" },
                        new Ingredient { Value = "2 cups finely chopped pickles" },
                        new Ingredient { Value = "5 hard-cooked eggs, chopped" },
                        new Ingredient { Value = "1/2 cup chopped red onion" },
                        new Ingredient { Value = "1/2 cup chopped celery" },
                        new Ingredient { Value = "3 tablespoons prepared mustard" },
                        new Ingredient { Value = "1 tablespoon apple cider vinegar" },
                        new Ingredient { Value = "1 teaspoon salt, or to taste" },
                        new Ingredient { Value = "1/2 teaspoon ground black pepper" }
                    },
                    Directions = new List<Direction>
                    {
                        new Direction { StepNumber = 1, Step = "Place potatoes into a large pot and cover with salted water; bring to a boil. Reduce heat to medium-low and simmer until tender, about 10 minutes.Drain.Return potatoes to empty pot to dry while you mix the dressing.Sprinkle with salt." },
                        new Direction { StepNumber = 2, Step = "Stir mayonnaise, pickles, hard - cooked eggs, red onion, celery, mustard, cider vinegar, 1 teaspoon salt, and pepper together in a large bowl.Fold potatoes into the mayonnaise mixture. Allow to chill at least six hours, or overnight, before serving." }
                    }
                },
                new Recipe{Title ="Marinated Cucumber, Onion, and Tomato Salad", Category = categories.ElementAt(2), Image = images.ElementAt(11), PrepTime = "2 hrs 15 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Value = "1 cup water" },
                        new Ingredient { Value = "1/2 cup distilled white vinegar"},
                        new Ingredient { Value = "1/4 cup vegetable oil"},
                        new Ingredient { Value = "1/4 cup sugar"},
                        new Ingredient { Value = "1 teaspoon salt, or to taste"},
                        new Ingredient { Value = "1 teaspoon freshly ground black pepper, or to taste"},
                        new Ingredient { Value = "3 cucumbers, peeled and sliced 1/4-inch thick"},
                        new Ingredient { Value = "3 tomatoes, cut into wedges"},
                        new Ingredient { Value = "1 onion, sliced and separated into rings"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction { StepNumber = 1, Step = "Whisk water, vinegar, oil, sugar, salt, and pepper together in a large bowl until smooth; add cucumbers, tomatoes, and onion and stir to coat."},
                        new Direction { StepNumber = 2, Step = "Cover bowl with plastic wrap; refrigerate for at least 2 hours." }
                    }
                },
                new Recipe{Title ="Awesome Pasta Salad", Category = categories.ElementAt(2), Image = images.ElementAt(12), PrepTime = "40 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Value = "1 (16 ounce) package fusilli (spiral) pasta" },
                        new Ingredient { Value = "3 cups cherry tomatoes, halved"},
                        new Ingredient { Value = "1/2 pound provolone cheese, cubed"},
                        new Ingredient { Value = "1/2 pound salami, cubed"},
                        new Ingredient { Value = "1/4 pound sliced pepperoni, cut in half"},
                        new Ingredient { Value = "1 large green bell pepper, cut into 1 inch pieces"},
                        new Ingredient { Value = "1 (10 ounce) can black olives, drained"},
                        new Ingredient { Value = "1 (4 ounce) jar pimentos, drained"},
                        new Ingredient { Value = "1 (8 ounce) bottle Italian salad dressing"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction { StepNumber = 1, Step = "Bring a large pot of lightly salted water to a boil. Cook fusilli in the boiling water, stirring occasionally, until tender yet firm to the bite, about 12 minutes. Drain." },
                        new Direction { StepNumber = 2, Step = "Combine fusilli with tomatoes, cheese, salami, pepperoni, green pepper, olives, and pimentos in a large bowl. Pour in salad dressing; toss to coat." }
                    }
                },
                new Recipe{Title ="Mom's Cucumber Salad", Category = categories.ElementAt(2), Image = images.ElementAt(13), PrepTime = "15 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Value = "1 cup mayonnaise" },
                        new Ingredient { Value = "1/4 cup white sugar"},
                        new Ingredient { Value = "4 teaspoons distilled white vinegar"},
                        new Ingredient { Value = "1/2 teaspoon dried dill weed"},
                        new Ingredient { Value = "1/2 teaspoon seasoned salt"},
                        new Ingredient { Value = "4 medium cucumbers, peeled and sliced"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction{StepNumber = 1, Step = "In a large bowl, stir together the mayonnaise, sugar, vinegar, dill, and seasoned salt. Mix in the cucumber slices, tossing to coat."}
                    }
                },
                new Recipe{Title ="Best Brownies", Category = categories.ElementAt(3), Image = images.ElementAt(14), PrepTime = "45 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Value = "1/2 cup butter" },
                        new Ingredient { Value = "1 cup white sugar"},
                        new Ingredient { Value = "2 eggs"},
                        new Ingredient { Value = "1 teaspoon vanilla extract"},
                        new Ingredient { Value = "1/3 cup unsweetened cocoa powder"},
                        new Ingredient { Value = "1/2 cup all-purpose flour"},
                        new Ingredient { Value = "1/4 teaspoon salt"},
                        new Ingredient { Value = "1/4 teaspoon baking powder"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction{StepNumber = 1, Step = "Preheat oven to 350 degrees F (175 degrees C). Grease and flour an 8-inch square pan." },
                        new Direction{StepNumber = 2, Step = "In a large saucepan, melt 1/2 cup butter. Remove from heat, and stir in sugar, eggs, and 1 teaspoon vanilla. Beat in 1/3 cup cocoa, 1/2 cup flour, salt, and baking powder. Spread batter into prepared pan." },
                        new Direction{StepNumber = 3, Step = "Bake in preheated oven for 25 to 30 minutes.Do not overcook." },
                        new Direction{StepNumber = 4, Step = "Remove brownies from the oven, and make frosting.Combine 3 tablespoons softened butter, 3 tablespoons cocoa, honey, 1 teaspoon vanilla extract, and 1 cup confectioners' sugar. Stir until smooth." },
                        new Direction{StepNumber = 5, Step = "Frost brownies while they are still warm." }
                    }
                },
                new Recipe{Title ="Best Chocolate Chip Cookies", Category = categories.ElementAt(3), Image = images.ElementAt(15), PrepTime = "1 hr", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Value = "1 cup butter, softened" },
                        new Ingredient { Value = "1 cup white sugar"},
                        new Ingredient { Value = "1 cup packed brown sugar"},
                        new Ingredient { Value = "2 eggs"},
                        new Ingredient { Value = "2 teaspoons vanilla extract"},
                        new Ingredient { Value = "1 teaspoon baking soda"},
                        new Ingredient { Value = "2 teaspoons hot water"},
                        new Ingredient { Value = "1/2 teaspoon salt"},
                        new Ingredient { Value = "3 cups all-purpose flour"},
                        new Ingredient { Value = "2 cups semisweet chocolate chips"},
                        new Ingredient { Value = "1 cup chopped walnuts"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction { StepNumber = 1, Step = "Preheat oven to 350 degrees F (175 degrees C)." },
                        new Direction { StepNumber = 2, Step = "Cream together the butter, white sugar, and brown sugar until smooth. Beat in the eggs one at a time, then stir in the vanilla. Dissolve baking soda in hot water. Add to batter along with salt. Stir in flour, chocolate chips, and nuts. Drop by large spoonfuls onto ungreased pans." },
                        new Direction { StepNumber = 3, Step = "Bake for about 10 minutes in the preheated oven, or until edges are nicely browned." }
                    }
                },
                new Recipe{Title ="Edible Cookie Dough", Category = categories.ElementAt(3), Image = images.ElementAt(16), PrepTime = "10 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Value = "3/4 cup packed brown sugar" },
                        new Ingredient { Value = "1/2 cup butter"},
                        new Ingredient { Value = "1 teaspoon vanilla extract"},
                        new Ingredient { Value = "1/2 teaspoon salt"},
                        new Ingredient { Value = "1 cup all-purpose flour"},
                        new Ingredient { Value = "2 tablespoons milk"},
                        new Ingredient { Value = "1/2 cup milk chocolate chips"},
                        new Ingredient { Value = "1/2 cup mini chocolate chips"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction{StepNumber = 1, Step = "Combine brown sugar and butter in a large bowl; beat with an electric mixer until creamy. Beat in vanilla extract and salt. Add flour; mix until a crumbly dough forms. Mix in milk. Fold in milk chocolate chips and mini chocolate chips."}
                    }
                },
                new Recipe{Title ="The Best Lemon Bars", Category = categories.ElementAt(3), Image = images.ElementAt(17), PrepTime = "55 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Value = "1 cup butter, softened"},
                        new Ingredient { Value = "½ cup white sugar"},
                        new Ingredient { Value = "2 cups all-purpose flour"},
                        new Ingredient { Value = "4 eggs"},
                        new Ingredient { Value = "1 1/2cups white sugar"},
                        new Ingredient { Value = "1/4 cup all-purpose flour"},
                        new Ingredient { Value = "2 lemons, juiced"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction{StepNumber = 1, Step = "Preheat oven to 350 degrees F (175 degrees C)." },
                        new Direction{StepNumber = 2, Step = "In a medium bowl, blend together softened butter, 2 cups flour and 1/2 cup sugar. Press into the bottom of an ungreased 9x13 inch pan." },
                        new Direction{StepNumber = 3, Step = "Bake for 15 to 20 minutes in the preheated oven, or until firm and golden.In another bowl, whisk together the remaining 1 1 / 2 cups sugar and 1 / 4 cup flour.Whisk in the eggs and lemon juice.Pour over the baked crust." },
                        new Direction{StepNumber = 4, Step = "Bake for an additional 20 minutes in the preheated oven.The bars will firm up as they cool.For a festive tray, make another pan using limes instead of lemons and adding a drop of green food coloring to give a very pale green. After both pans have cooled, cut into uniform 2 inch squares and arrange in a checker board fashion." }
                    }
                },
                new Recipe{Title ="How to Make Vanilla Ice Cream", Category = categories.ElementAt(3), Image = images.ElementAt(18), PrepTime = "2 hrs 35 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Value = "3/4 cup white sugar" },
                        new Ingredient { Value = "1 cup heavy whipping cream"},
                        new Ingredient { Value = "2 1/4 cups milk"},
                        new Ingredient { Value = "2 teaspoons vanilla extract"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction{StepNumber = 1, Step = "Stir sugar, cream, and milk into a saucepan over low heat until sugar has dissolved. Heat just until mix is hot and a small ring of foam appears around the edge." },
                        new Direction{StepNumber = 2, Step = "Transfer cream mixture to a pourable container such as a large measuring cup. Stir in vanilla extract and chill mix thoroughly, at least 2 hours. (Overnight is best.)" },
                        new Direction{StepNumber = 3, Step = "Pour cold ice cream mix into an ice cream maker, turn on the machine, and churn according to manufacturer's directions, 20 to 25 minutes." },
                        new Direction{StepNumber = 4, Step = "When ice cream is softly frozen, serve immediately or place a piece of plastic wrap directly on the ice cream and place in freezer to ripen, 2 to 3 hours." }
                    }
                },
                new Recipe{Title ="Old-Fashioned Lemonade", Category = categories.ElementAt(5), Image = images.ElementAt(19), PrepTime = "10 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Value = "6 lemons" },
                        new Ingredient { Value = "1 cup white sugar"},
                        new Ingredient { Value = "6 cups water, or more as needed"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction{StepNumber = 1, Step = "Juice lemons; you should have 1 cup juice." },
                        new Direction{StepNumber = 2, Step = "Combine juice, sugar, and water in a 1 / 2 - gallon pitcher.Stir until sugar dissolves. Taste and add more water if desired." },
                        new Direction{StepNumber = 3, Step = "Chill and serve over ice." }
                    }
                },
                new Recipe{Title ="Parker's Famous Margaritas", Category = categories.ElementAt(5), Image = images.ElementAt(20), PrepTime = "5 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Value = "5 fluid ounces tequila" },
                        new Ingredient { Value = "3 fluid ounces fresh lime juice "},
                        new Ingredient { Value = "1 fluid ounce sweetened lime juice "},
                        new Ingredient { Value = "3 fluid ounces triple sec (orange-flavored liqueur)"},
                        new Ingredient { Value = "ice cubes"},
                        new Ingredient { Value = "1 lime, cut into wedges"},
                        new Ingredient { Value = "rimming salt"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction{StepNumber = 1, Step = "Measure the tequila, lime juice, sweetened lime juice and triple sec into a cocktail shaker and add a generous scoop of ice. Cover and shake until the shaker is frosty, about 30 seconds." },
                        new Direction{StepNumber = 2, Step = "Rub a lime wedge around the rim of a margarita glass and dip in salt. Fill each glass with ice. Strain equal amounts of the cocktail into the glasses to serve. Garnish with a lime wedge." }
                    }
                },
                new Recipe{Title ="Best Strawberry Daiquiri", Category = categories.ElementAt(5), Image = images.ElementAt(21), PrepTime = "10 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Value = "6 cups ice" },
                        new Ingredient { Value = "1/2 cup white sugar"},
                        new Ingredient { Value = "4 ounces frozen strawberries"},
                        new Ingredient { Value = "1/8 cup lime juice"},
                        new Ingredient { Value = "1/2 cup lemon juice"},
                        new Ingredient { Value = "3/4 cup rum"},
                        new Ingredient { Value = "1/4 cup lemon-lime flavored carbonated beverage"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction{StepNumber = 1, Step = "In a blender, combine ice, sugar and strawberries. Pour in lime juice, lemon juice, rum and lemon-lime soda. Blend until smooth. Pour into glasses and serve."}
                    }
                },
                new Recipe{Title ="Strawberry Mojito", Category = categories.ElementAt(5), Image = images.ElementAt(22), PrepTime = "15 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Value = "white sugar, for rimming" },
                        new Ingredient { Value = "2 large limes, quartered"},
                        new Ingredient { Value = "1/2 bunch mint leaves"},
                        new Ingredient { Value = "7 strawberries, quartered"},
                        new Ingredient { Value = "1 cup white sugar"},
                        new Ingredient { Value = "1 cup white rum"},
                        new Ingredient { Value = "2 cups club soda"},
                        new Ingredient { Value = "8 cups ice cubes"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction{StepNumber = 1, Step = "Pour 1/4 to 1/2 inch of sugar onto a small, shallow plate. Run one of the lime quarters around the rim of each cocktail glass, then dip the glasses into the sugar to rim; set aside." },
                        new Direction{StepNumber = 2, Step = "Squeeze all of the lime quarters into a sturdy glass pitcher. Toss the juiced limes into the pitcher along with the mint, strawberries, and 1 cup of sugar.Crush the fruits together with a muddler to release the juices from the strawberries and the oil from the mint leaves.Stir in the rum and club soda until the sugar has dissolved. Pour into the sugared glasses over ice cubes to serve." }
                    }
                },
                new Recipe{Title ="Classic Old Fashioned", Category = categories.ElementAt(5), Image = images.ElementAt(23), PrepTime = "10 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Value = "2 teaspoons simple syrup" },
                        new Ingredient { Value = "1 teaspoon water"},
                        new Ingredient { Value = "2 dashes bitters"},
                        new Ingredient { Value = "1 cup ice cubes"},
                        new Ingredient { Value = "1 (1.5 fluid ounce) jigger bourbon whiskey"},
                        new Ingredient { Value = "1 slice orange"},
                        new Ingredient { Value = "1 maraschino cherry"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction{StepNumber = 1, Step = "Pour the simple syrup, water, and bitters into a whiskey glass. Stir to combine, then place the ice cubes in the glass. Pour bourbon over the ice and garnish with the orange slice and maraschino cherry."}
                    }
                },
                new Recipe{Title ="Classic Bloody Mary", Category = categories.ElementAt(5), Image = images.ElementAt(24), PrepTime = "2 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Value = "1 teaspoon sea salt, or as needed" },
                        new Ingredient { Value = "ice cubes, as needed"},
                        new Ingredient { Value = "3/4 cup spicy tomato-vegetable juice cocktail (such as V8®)"},
                        new Ingredient { Value = "1 (1.5 fluid ounce) jigger vodka"},
                        new Ingredient { Value = "2 dashes Worcestershire sauce"},
                        new Ingredient { Value = "1 dash hot pepper sauce (such as Tabasco®)"},
                        new Ingredient { Value = "salt and ground black pepper to taste"},
                        new Ingredient { Value = "1 stalk celery"},
                        new Ingredient { Value = "2 garlic-stuffed green olives, threaded onto a toothpick"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction{StepNumber = 1, Step = "Pour salt onto a small plate. Moisten the rim of a glass and press into the salt. Fill the glass with ice cubes." },
                        new Direction{StepNumber = 2, Step = "Fill a cocktail shaker with ice cubes; add vegetable juice cocktail, vodka, Worcestershire sauce, hot pepper sauce, salt, and pepper. Cover and shake until the outside of shaker has frosted, about 20 seconds." },
                        new Direction{StepNumber = 3, Step = "Strain Bloody Mary into the prepared glass and garnish with celery stalk and olives." }
                    }
                },
                new Recipe{Title ="Naan", Category = categories.ElementAt(4), Image = images.ElementAt(25), PrepTime = "2 hrs 30 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Value = "1 (.25 ounce) package active dry yeast" },
                        new Ingredient { Value = "1 cup warm water"},
                        new Ingredient { Value = "1/4 cup white sugar"},
                        new Ingredient { Value = "3 tablespoons milk"},
                        new Ingredient { Value = "1 large egg, beaten"},
                        new Ingredient { Value = "2 teaspoons salt"},
                        new Ingredient { Value = "4 1/2 cups bread flour"},
                        new Ingredient { Value = "2 teaspoons minced garlic (Optional)"},
                        new Ingredient { Value = "1/4 cup butter, melted"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction{StepNumber = 1, Step = "Dissolve yeast in warm water in a large bowl. Let stand about 10 minutes, until frothy." },
                        new Direction{StepNumber = 2, Step = "Meanwhile, generously oil a large bowl." },
                        new Direction{StepNumber = 3, Step = "Stir sugar, milk, egg, and salt into the yeast mixture. Mix in enough flour to make a soft dough." },
                        new Direction{StepNumber = 4, Step = "Knead dough on a lightly floured surface until smooth, 6 to 8 minutes." },
                        new Direction{StepNumber = 5, Step = "Place dough in the prepared oil, cover with a damp cloth, and let rise until doubled in size, about 1 hour." },
                        new Direction{StepNumber = 6, Step = "Punch down dough on a lightly floured surface, and knead in garlic. Pinch off small handfuls of dough about the size of a golf ball; you should have about 1" },
                        new Direction{StepNumber = 7, Step = "Roll each piece into a ball and place on a tray. Cover with a towel, and allow to rise until doubled in size, about 30 minutes." },
                        new Direction{StepNumber = 8, Step = "Meanwhile, preheat a large grill pan over high heat." },
                        new Direction{StepNumber = 9, Step = "Roll each piece of dough into a thin circle." },
                        new Direction{StepNumber = 10, Step = "Brush some melted butter on the preheated grill pan. Place a few pieces of dough in the pan(as many as you can fit) and cook until puffy and lightly browned, 2 to 3 minutes.Brush butter onto the uncooked sides, flip, and cook until browned, 2 to 4 more minutes. Remove from the grill and repeat to cook the remaining naan." },
                    }
                },
                new Recipe{Title ="Belle's Hamburger Buns", Category = categories.ElementAt(4), Image = images.ElementAt(26), PrepTime = "2 hrs 20 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Value = "1 cup milk" },
                        new Ingredient { Value = "1 cup water"},
                        new Ingredient { Value = "2 tablespoons butter"},
                        new Ingredient { Value = "1 tablespoon white sugar"},
                        new Ingredient { Value = "1 1/2 teaspoons salt"},
                        new Ingredient { Value = "5 1/2 cups all-purpose flour"},
                        new Ingredient { Value = "1 (.25 ounce) envelope active dry yeast"},
                        new Ingredient { Value = "1 egg yolk"},
                        new Ingredient { Value = "1 tablespoon water"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction{StepNumber = 1, Step = "Combine the milk, 1 cup of water, butter, sugar and salt in a saucepan. Bring to a boil then remove from the heat and let stand until lukewarm. If the mixture is too hot, it will kill the yeast." },
                        new Direction{StepNumber = 2, Step = "In a large bowl, stir together the flour and yeast. Pour in wet ingredients and stir until the dough starts to pull together. If you have a stand mixer, use the dough hook to mix for about 8 minutes.If not, knead the dough on a floured surface for about 10 minutes.Place the dough in a greased bowl, turning to coat.Cover and let stand until doubled in size, about 1 hour." },
                        new Direction{StepNumber = 3, Step = "Punch down the dough and divide into 12 portions They should be a little larger than a golf ball.Make tight balls out of the dough by pulling the dough tightly around and pinching it at the bottom.Place on a baking sheet lined with parchment paper or aluminum foil.After the rolls sit for a minute and relax, flatten each ball with the palm of your hand until it is 3 to 4 inches wide.You may want to oil your hand first.Set rolls aside until they double in size, about 20 minutes." },
                        new Direction{StepNumber = 4, Step = "Preheat the oven to 400 degrees F(200 degrees C).Mix together the egg yolk and 1 tablespoon of water in a cup or small bowl.Brush onto the tops of the rolls.Position 2 oven racks so they are not too close to the top or bottom of the oven." },
                        new Direction{StepNumber = 5, Step = "Bake for 10 minutes in the preheated oven.Remove the rolls from the oven and return them to different shelves so each one spends a little time on the top.Continue to bake for another 5 to 10 minutes, or until nicely browned on the top and bottom." }
                    }
                },
                new Recipe{Title ="Banana Chocolate Chip Bread", Category = categories.ElementAt(4), Image = images.ElementAt(27), PrepTime = "1 hr 25 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Value = "2 cups all-purpose flour" },
                        new Ingredient { Value = "1 teaspoon baking powder"},
                        new Ingredient { Value = "1 teaspoon baking soda"},
                        new Ingredient { Value = "1 teaspoon salt"},
                        new Ingredient { Value = "3 ripe bananas, mashed"},
                        new Ingredient { Value = "1 tablespoon milk"},
                        new Ingredient { Value = "1 teaspoon ground cinnamon, or to taste"},
                        new Ingredient { Value = "1/2 cup butter, softened"},
                        new Ingredient { Value = "1 cup white sugar"},
                        new Ingredient { Value = "2 eggs"},
                        new Ingredient { Value = "1 cup semisweet chocolate chips"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction{StepNumber = 1, Step = "Preheat oven to 325 degrees F (165 degrees C). Grease a 9x5-inch loaf pan, preferably glass." },
                        new Direction{StepNumber = 2, Step = "Mix flour, baking powder, baking soda, and salt in a bowl. Stir bananas, milk, and cinnamon in another bowl. Beat butter and sugar in a third bowl until light and fluffy. Add eggs to butter mixture, one at a time, beating well after each addition. Stir banana mixture into butter mixture. Stir in dry mixture until blended. Fold in chocolate chips until just combined. Pour batter into prepared loaf pan." },
                        new Direction{StepNumber = 3, Step = "Bake in the preheated oven until a toothpick inserted into the center comes out clean, about 70 minutes. Cool in the pan for 10 minutes before removing to cool completely on a wire rack before slicing." }
                    }
                },
                new Recipe{Title ="Simple Whole Wheat Bread", Category = categories.ElementAt(4), Image = images.ElementAt(28), PrepTime = "2 hrs 50 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Value = "3 cups warm water (110 degrees F/45 degrees C)" },
                        new Ingredient { Value = "2 (.25 ounce) packages active dry yeast"},
                        new Ingredient { Value = "2/3 cup honey, divided"},
                        new Ingredient { Value = "5 cups bread flour"},
                        new Ingredient { Value = "5 tablespoons butter, melted, divided"},
                        new Ingredient { Value = "1 tablespoon salt"},
                        new Ingredient { Value = "4 cups whole wheat flour, or more as needed"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction{StepNumber = 1, Step = "Mix warm water, yeast, and 1/3 cup honey in a large bowl to dissolve. Add 5 cups bread flour, and stir to combine. Let sit for 30 minutes, or until big and bubbly." },
                        new Direction{StepNumber = 2, Step = "Mix in 3 tablespoons melted butter, remaining 1 / 3 cup honey, and salt.Stir in 2 cups whole wheat flour.Transfer dough to a floured work surface and gradually knead in remaining 2 cups whole wheat flour.Knead until dough starts to pull away from the work surface, adding more whole wheat flour if necessary; dough should be a bit tacky to the touch, but not too sticky." },
                        new Direction{StepNumber = 3, Step = "Place in a greased bowl, turning once to coat the surface of the dough.Cover with a dish towel and let rise in a warm place until doubled, 45 minutes to 1 hour." },
                        new Direction{StepNumber = 4, Step = "Grease three 9x5 - inch loaf pans. Punch down the dough, and divide it into 3 loaves.Place in the prepared loaf pans, and allow to rise until dough has topped the pans by one inch, another 45 minutes to 1 hour." },
                        new Direction{StepNumber = 5, Step = "Meanwhile, preheat the oven to 350 degrees F(175 degrees C)." },
                        new Direction{StepNumber = 6, Step = "Bake the risen loaves in the preheated oven until golden brown for 25 to 30 minutes, do not overbake." },
                        new Direction{StepNumber = 7, Step = "Lightly brush the tops of the loaves with remaining 2 tablespoons melted butter when done to prevent crust from getting hard.Cool completely." }
                    }
                },
                new Recipe{Title ="Brioche", Category = categories.ElementAt(4), Image = images.ElementAt(29), PrepTime = "1 day 3 hrs 20 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Value = "1 tablespoon active dry yeast" },
                        new Ingredient { Value = "1/3 cup warm water (110 degrees F)"},
                        new Ingredient { Value = "3 1/2 cups all-purpose flour"},
                        new Ingredient { Value = "1 tablespoon white sugar"},
                        new Ingredient { Value = "1 teaspoon salt"},
                        new Ingredient { Value = "4 eggs"},
                        new Ingredient { Value = "1 cup butter, softened"},
                        new Ingredient { Value = "1 egg yolk"},
                        new Ingredient { Value = "1 teaspoon cold water"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction{StepNumber = 1, Step = "In a small bowl, dissolve yeast in warm water. Let stand until creamy, about 10 minutes." },
                        new Direction{StepNumber = 2, Step = "In a large bowl, stir together the flour sugar and salt. Make a well in center of the bowl and mix in the eggs and yeast mixture. Beat well until the dough has pulled together, then turn it out onto a lightly floured surface and knead until smooth and supple, about 8 minutes." },
                        new Direction{StepNumber = 3, Step = "Flatten the dough and spread it with one third of the butter. Knead this well. Repeat this twice to incorporate the remaining butter. Allow the dough to rest for a few minutes between additions of butter.This process may take 20 minutes or so.Lightly oil a large bowl, place the dough in the bowl and turn to coat with oil.Cover with plastic wrap and let rise in a warm place until doubled in volume, about 1 hour." },
                        new Direction{StepNumber = 4, Step = "Deflate the dough, cover with plastic wrap, and refrigerate 6 hours or overnight.It needs time to chill in order to become more workable." },
                        new Direction{StepNumber = 5, Step = "Turn the dough out onto a lightly floured surface.Divide the dough into two equal pieces, form into loaves and place into prepared pans.Cover with greased plastic wrap and let rise until doubled in volume, about 60 minutes.Turn the dough out onto a lightly floured surface.Divide the dough into two equal pieces, form into loaves and place into prepared pans.Cover with greased plastic wrap and let rise until doubled in volume, about 60 minutes." },
                        new Direction{StepNumber = 6, Step = "Preheat oven to 400 degrees F(200 degrees C).Lightly grease two 9x5 - inch loaf pans(see Cook's Note to make rolls). Beat the egg yolk with 1 teaspoon of water to make a glaze." },
                        new Direction{StepNumber = 7, Step = "Brush the loaves or rolls with the egg wash.Bake in preheated oven until a deep golden brown.Start checking the loaves for doneness after 25 minutes, and rolls at 10 minutes.Let the loaves cool in the pans for 10 minutes before moving them to wire racks to cool completely." }
                    }
                },
                new Recipe{Title ="Traditional Layered French Croissants", Category = categories.ElementAt(4), Image = images.ElementAt(30), PrepTime = "1 day 6 hrs 45 mins", Author = users.First(),
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Value = "2 tablespoons all-purpose flour" },
                        new Ingredient { Value = "1 1/2 cups unsalted butter, at room temperature"},
                        new Ingredient { Value = "4 cups all-purpose flour, divided"},
                        new Ingredient { Value = "1/2 teaspoon salt"},
                        new Ingredient { Value = "3 tablespoons sugar"},
                        new Ingredient { Value = "2 (.25 ounce) packages active dry yeast"},
                        new Ingredient { Value = "1/4 cup lukewarm water"},
                        new Ingredient { Value = "1 cup milk"},
                        new Ingredient { Value = "1/2 cup heavy cream"},
                        new Ingredient { Value = "1 egg"},
                        new Ingredient { Value = "1 tablespoon water"}
                    },
                    Directions = new List<Direction>
                    {
                        new Direction{StepNumber = 1, Step = "Sprinkle 2 tablespoons of flour over the butter and mix it together with your hands in a mixing bowl or on a work surface. Transfer the butter to a length of foil or parchment paper and pat it into a 6 inch square. Fold up the foil to make a packet and refrigerate until chilled, about 2 hours." },
                        new Direction{StepNumber = 2, Step = "Combine 2 cups of the flour with the salt and sugar in a mixing bowl. Dissolve the yeast in the lukewarm water (100 degrees F/38 degrees C) and set aside until frothy, about 10 minutes. Meanwhile, warm the milk and the heavy cream to lukewarm. Add the yeast, milk, and cream to the flour mixture and stir well. The dough will have a batter-like consistency." },
                        new Direction{StepNumber = 3, Step = "Stir in the remaining 2 cups of flour 1/4 cup at a time to form a soft dough. It should no longer be sticky. Turn the dough onto a lightly floured work surface and knead until smooth, about 5 minutes. Place the dough in a mixing bowl and cover with plastic wrap. Refrigerate for 1 hour." },
                        new Direction{StepNumber = 4, Step = "To begin the rolling and folding process, both the butter and the dough should be at a cool room temperature. [See Cook's Note.] Place the dough on a floured surface and roll it into a 10-inch square. Set the block of butter diagonally on the square dough. Bring each point of dough to the center of the butter square; the edges of the dough should overlap. Pinch the edges together to seal." },
                        new Direction{StepNumber = 5, Step = "Starting from the center of the square and working outward, use a rolling pin to roll the dough out into a rectangle.The butter should be pliable enough to roll smoothly with the dough; if it's too soft and starts to ooze out the corners, wrap the dough in plastic and refrigerate before proceeding. Roll the dough into a long rectangle, approximately 8 by 18 inches. Fold the length of dough into thirds, like a business letter." },
                        new Direction{StepNumber = 6, Step = "If the dough is still cool, you can continue with another fold.Otherwise, wrap it in plastic and refrigerate for 45 minutes to 1 hour.Remove the dough from the refrigerator and let it warm up for about 10 minutes before you begin rolling it out again." },
                        new Direction{StepNumber = 7, Step = "Position the dough so that the open ends are at 12 and 6 o'clock. Roll the dough into a rectangle, working from the center of the dough and pressing outwards. Reposition the dough as necessary to fit your work space. You should have a long rectangle for the 'book fold.' Fold both ends of the dough into the middle; the ends don't have to be touching, but should be close.Fold the already - folded dough in half; it will look like a thick book.Wrap the dough well with plastic and refrigerate for 1 to 2 hours." },
                        new Direction{StepNumber = 8, Step = "Remove the dough from the refrigerator and let it rest at room temperature for about 20 minutes.Roll the dough into a rectangle again and fold it into thirds, like a business letter.Wrap it in plastic and refrigerate for 4 - 6 hours or overnight." },
                        new Direction{StepNumber = 9, Step = "To shape the croissants, roll the dough into a 10 - by 38 - inch rectangle on a lightly floured work surface.It should be about 1 / 4 inch thick.Use a pizza wheel or sharp paring knife to trim the edges of the dough.Divide the rectangle in half so that you have two 5 - inch wide strips of dough.Use a clean yardstick to mark each strip into triangles that are 5 inches wide at their bases.Cut the triangles and place them onto parchment - lined baking sheets.Chill for 15 to 20 minutes, if necessary." },
                        new Direction{StepNumber = 10, Step = "Starting at the base of the triangle, roll the dough up into a log; the tip of the triangle should be under the body of the croissant to prevent it from unraveling.Bend in the corners to form the traditional crescent shape.Repeat with the remaining dough." },
                        new Direction{StepNumber = 11, Step = "Arrange the croissants on the parchment - lined baking sheets and allow to rise until doubled in size, about 1 to 2 hours." },
                        new Direction{StepNumber = 12, Step = "Preheat an oven to 425 degrees F(220 degrees C). Beat the egg with the tablespoon of water to make the egg wash.Brush the croissants with egg wash and bake in the preheated oven until deep brown, 22 to 25 minutes.Cool on a rack before serving." }
                    }
                }
            };

            var useCases = new List<UseCase>
            {

            };

            for(int i = 1; i <= 24; i++)
            {
                useCases.Add(new UseCase { User = users.ElementAt(2), UseCaseId = i });
            }

            var useCaseIds = new List<int> { 1, 2, 3, 4, 7, 23 };

            for (int i = 15; i <= 21; i++) 
                useCaseIds.Add(i);

            foreach (var id in useCaseIds) 
            { 
                useCases.Add(new UseCase { User = users.ElementAt(0), UseCaseId = id });
                useCases.Add(new UseCase { User = users.ElementAt(1), UseCaseId = id });
            }

            this.DbContext.Categories.AddRange(categories);
            this.DbContext.Images.AddRange(images);
            this.DbContext.Users.AddRange(users);
            this.DbContext.Recipes.AddRange(recipes);
            this.DbContext.UseCases.AddRange(useCases);

            this.DbContext.SaveChanges();

        }
    }
}
