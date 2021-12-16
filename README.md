# Ecosystem
  ### An Ecosystem built in Unity that simulates evolution using reinforcement machine learning
  
  ### C# Unity code can be found in Ecosystem\Assets\Ecosystem\Scripts
  
  ### All Unity assets are custom made for this project in blender and can be found in Ecosystem\Assets\Ecosystem\Meshes
  
  #### **How the project works in its current state:**
  
  At the moment, the project has a single rabbit spawn in an area along with a few bushes, trees, and rocks. The rabbit must learn to find bushes to eat in the shortest amount of time. The rabbit's brain is a machine learning neural network that is able to learn the optimal way to find bushes.

### Images from Current Simulation

**The environment with all assets ready to run**

![image](https://user-images.githubusercontent.com/34993121/131057766-a2c8f9d5-8c30-4883-a8bb-e45f3a7da3a4.png)

**Rabbit about to eat bush full of berries**

![image](https://user-images.githubusercontent.com/34993121/131058215-99d96d6f-c6a3-4b12-9e19-571ba0e53036.png)

**Rabbit before learning how to find and eat berries**

![Rabbit train GIF](https://user-images.githubusercontent.com/34993121/146284361-d1f2ca19-678d-44c2-8522-535876dcb77b.gif)

Notice how it is constantly running in circles or hitting the edge of the envionment, but will occasionally get lucky and find a berry bush to eat.

**Rabbit after learning how to find and eat berries**

![Rabbit GIF](https://user-images.githubusercontent.com/34993121/146282895-7390ef6a-b13f-487f-b689-32b452257f6c.gif)

Now that the rabbit has learned to eat the berries, it immediately runs towards them once it has detected one. Also notice that the rabbit does small 'jiggles' before it finds a berry bush. This behavior was learned and allows the rabbit to quickly scan ahead of it in a wider area compared to just going staright, minimizing the time it takes to find a berry bush. A really cool behavior that I would have never thought to do!

#### **Future goals:**
  
  The next step in this project is to have a multi-day simulation that will enable the rabbit population to grow each day depending on how many bushes each rabbit can eat. The addition of a multi-day system will also enable the implementation of a mutation system where every time a rabbit gives birth, its offspring have a random chance to slightly change their attributes. Tools for tracking rabbit population over time will also need to be created.
  
  Once a proper day cycle has been implemented, the next step will be to introduce more animals to the ecosystem. For example, a fox will be added that must learn, using a neural network, to hunt rabbits in order to survive. The foxes will also have the ability to evolve over time and will interact dynamically with the rabbits. More animals and further increases to the size of the ecosystem area will also enable better simulations.
  
  Eventually, the final goal as of now for this project will be to implement a mutation system for the neural network of each animal. Rather than evolving attributes like speed, sight, and height, this final step of the project will aim to provide a way for the brain complexity of animals to change over time so that we can have a better picture of when more or less intelligence evolves. What situations warrant the extra energy usage that a large brain demands? Which animals will evolve to have larger brains and which will opt for less demanding and simple brains? At this stage in the project, the goal will be to study what environmental factors determine the intelligence of organisms and could be an informative look into what led humans to become more intelligent. Additionally, we could use this simulation to estimate how likely it is for highly intelligent organisms to evolve. Will super intelligent organisms evolve once every 100 simulations? 1,000? 1,000,000? How rare is super intelligence and how common should we expect it to be in our own universe?


