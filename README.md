# 🚗 Hazardaz-Drive

> **A Unity-based endless driving game focused on fast-paced arcade gameplay, obstacle avoidance, collectible points, health management, and an infinite moving-road illusion.**

---

## 🎮 About

**Hazardaz-Drive** is an arcade-style endless driving game developed using **Unity 6.3 LTS and C#**.

The core concept is to create the illusion of a car driving continuously at high speed without requiring the player vehicle to travel through a massive world.

Instead, the **road, terrain, obstacles, collectibles, trees, mountains, and other environmental elements continuously move toward the player**.

This creates the visual effect of high-speed driving while allowing the game world to be efficiently reused.

### 🎯 The player must:

* 🚗 Control the car
* 🛣️ Stay on the road
* 💨 Survive as long as possible
* 🪙 Collect points
* 🚧 Avoid hazards
* ❤️ Manage vehicle health
* 💥 Survive collisions
* 🏆 Achieve the highest possible score

---

The player's car remains relatively fixed in the forward direction while the environment continuously moves toward it.

This creates an **endless road / infinite driving effect**.

---

# ✨ Core Features

## 🚗 Player Car

* Player-controlled vehicle
* Left and right movement
* Steering
* Collision detection
* Vehicle health system
* Collision feedback
* Game-over condition

---

## 🛣️ Endless Road System

The road continuously moves toward the player.

Instead of creating an enormous road, the game can reuse multiple road segments.

When a road segment moves behind the player, it can be repositioned to the front.

This creates an **infinite-road illusion** while keeping the environment efficient.

---

## 🌲 Environment

The game environment can contain:

* 🌲 Small trees
* 🌳 Large trees
* 🌿 Bushes
* ⛰️ Mountains
* 🏔️ Hills
* 🌱 Grass
* 🚦 Roadside objects
* 🪨 Environmental objects
* 🛣️ Road decorations

Environmental elements continuously move toward the player together with the road.

---

## 🚧 Obstacles

Obstacles create the main gameplay challenge.

Possible hazards include:

* 🚘 Traffic vehicles
* 🚧 Road barriers
* 🪨 Rocks
* 📦 Fallen objects
* 🏗️ Construction objects
* ⚠️ Environmental hazards

The obstacle system can become progressively more challenging as gameplay continues.

---

## 🪙 Collectible Points

Collectible objects appear along the road.

When the player collects one, the score increases.

```text
Collectible
     ↓
  Collision
     ↓
  Score +1
     ↓
  Collectible Disappears
     ↓
    UI Updates
```

Example:

```text
SCORE: 1250
```

---

## ❤️ Health System

The player vehicle has a health value.

```text
❤️ HEALTH: 100
```

When the car collides with an obstacle:

```text
Collision
   ↓
Health Decreases
   ↓
Player Feedback
   ↓
Continue / Game Over
```

When health reaches zero:

```text
HEALTH = 0
     ↓
 GAME OVER
```

---

## 💥 Collision System

Unity's physics system will be used to handle collision detection.

Potential collisions include:

* 🚗 Car vs obstacle
* 🚗 Car vs collectible
* 🚗 Car vs environment
* 🛣️ Road boundary detection

Collisions may trigger:

* ❤️ Health reduction
* 🪙 Score updates
* ✨ Particle effects
* 🔊 Sound effects
* 📳 Screen effects
* 🎬 Vehicle animations
* 💀 Game-over logic

---

# 🖥️ User Interface

The gameplay HUD will display important information.

### Planned UI

* 🪙 Score counter
* ❤️ Health indicator
* ▶️ Start screen
* ⏸️ Pause menu
* 💀 Game-over screen
* 🔄 Restart button
* 🏆 High-score display

---

# 🎬 Game Over System

When the player's health reaches zero, the game transitions into a **Game Over** state.

Possible effects include:

* 💥 Car crash animation
* ✨ Particle effects
* 📳 Camera shake
* 🔊 Crash sound
* 🖥️ UI transition
* 🏆 Final score display

---

# 🧠 Game Architecture

The project is designed around separate gameplay systems.

```text
                    GAME MANAGER
                         │
        ┌────────────────┼────────────────┐
        ↓                ↓                ↓
   PLAYER SYSTEM    ROAD SYSTEM       UI SYSTEM
        │                │                │
        ↓                ↓                ↓
   HEALTH SYSTEM    ENVIRONMENT       SCORE SYSTEM
        │             MOVEMENT             │
        ↓                │                 ↓
 COLLISION SYSTEM ───────┴────────── COLLECTIBLES
        │
        ↓
   GAME OVER SYSTEM
```

This architecture helps keep the project **modular, maintainable, reusable, and easier to expand**.

---

# ⚙️ Gameplay Systems

## 🚗 Player System

Responsible for:

* Player movement
* Steering
* Car controls
* Player state

## 🛣️ Road Movement System

Responsible for:

* Continuous road movement
* Road segment recycling
* Infinite-road illusion

## 🌲 Environment System

Responsible for:

* Trees
* Mountains
* Terrain
* Roadside objects
* Environment recycling

## 🚧 Obstacle System

Responsible for:

* Obstacle spawning
* Obstacle movement
* Collision detection
* Difficulty progression

## 🪙 Collectible System

Responsible for:

* Collectible spawning
* Collection detection
* Score rewards
* Object recycling

## ❤️ Health System

Responsible for:

* Player health
* Damage
* Health UI
* Game-over condition

## 🏆 Score System

Responsible for:

* Score calculation
* Collectible rewards
* Survival / distance score
* High-score tracking

## 🖥️ UI System

Responsible for:

* Score display
* Health display
* Start menu
* Pause menu
* Game-over screen

## 🎮 Game Manager

Responsible for:

* Game states
* Starting gameplay
* Pausing gameplay
* Game over
* Restarting the game

---

# 🎮 Controls

| Input               | Action                |
| ------------------- | --------------------- |
| `A` / `Left Arrow`  | Move Left             |
| `D` / `Right Arrow` | Move Right            |
| `W` / `Up Arrow`    | Optional Acceleration |
| `S` / `Down Arrow`  | Optional Braking      |
| `Esc`               | Pause                 |

> Controls may change during development.

---

# 🛠️ Technology Stack

| Technology        | Purpose                          |
| ----------------- | -------------------------------- |
| **Unity 6.3 LTS** | Game Engine                      |
| **C#**            | Gameplay Programming             |
| **Unity Physics** | Collision Detection & Physics    |
| **Unity UI**      | User Interface                   |
| **Git**           | Version Control                  |
| **GitHub**        | Source Code & Project Management |

---

# 🖥️ Target Platforms

Hazardaz-Drive is being developed with **cross-platform deployment** in mind.

| Platform       | Target  |
| -------------- | ------- |
| 🤖 **Android** | Mobile  |
| 🍎 **iOS**     | Mobile  |
| 🪟 **Windows** | Desktop |
| 🐧 **Linux**   | Desktop |
| 🍎 **macOS**   | Desktop |
| 🌐 **Web**     | Browser |

The project will be tested and optimized for each supported platform to provide a consistent gameplay experience.

---

# 📋 Feature Checklist

> All development tasks are currently tracked without marking them as completed.

### 🚗 Core Gameplay

* [x] Unity project setup
* [x] Basic game scene
* [x] Player car
* [x] Basic car movement
* [x] Road environment
* [x] Continuous road movement
* [x] Environment movement
* [x] Obstacle system
* [x] Collectible system
* [x] Score system
* [x] Health system
* [x] Collision system
* [x] Game-over system
* [x] Gameplay UI
* [x] Restart system
* [x] Audio
* [x] Visual effects
* [ ] Difficulty progression

---

# 🚧 Development Roadmap

## Phase 1 — Project Setup

* [x] Create Unity project
* [x] Configure project settings
* [x] Create GitHub repository
* [x] Configure `.gitignore`
* [x] Create folder structure
* [x] Create initial scene

---

## Phase 2 — Player System

* [x] Import/create car model
* [x] Create player GameObject
* [x] Configure Rigidbody
* [x] Create car controller
* [x] Implement left/right movement
* [x] Configure collision detection
* [x] Test player controls

---

## Phase 3 — Road System

* [x] Create road
* [x] Create reusable road segments
* [x] Implement road movement
* [x] Implement road recycling
* [x] Test infinite-road illusion
* [ ] Optimize road generation

---

## Phase 4 — Environment

* [ ] Add trees
* [ ] Add bushes
* [ ] Add roadside objects
* [ ] Implement environment movement
* [ ] Implement environment recycling
* [ ] Improve scene composition

---

## Phase 5 — Obstacles

* [x] Create obstacle prefabs
* [x] Create obstacle spawning system
* [x] Randomize obstacle positions
* [x] Implement collision detection
* [x] Implement obstacle recycling
* [ ] Add difficulty progression

---

## Phase 6 — Collectibles & Score

* [x] Create collectible prefab
* [x] Implement collectible spawning
* [x] Detect collection
* [x] Create score manager
* [x] Update score UI
* [x] Add collectible effects
* [x] Add collectible sound

---

## Phase 7 — Health & Damage

* [x] Create health system
* [x] Implement collision damage
* [x] Create health UI
* [ ] Add damage feedback
* [x] Add crash effects
* [ ] Implement zero-health condition

---

## Phase 8 — Game State

* [x] Create Game Manager
* [x] Start game state
* [x] Playing state
* [x] Pause state
* [x] Game-over state
* [x] Restart system

---

## Phase 9 — UI & UX

* [ ] Main menu
* [ ] Gameplay HUD
* [x] Score display
* [x] Health display
* [x] Pause menu
* [x] Game-over screen
* [x] Restart button
* [ ] UI animations

---

## Phase 10 — Audio & Effects

* [ ] Engine sound
* [x] Collision sound
* [x] Collectible sound
* [x] Background music
* [x] Crash effects
* [x] Particle effects
* [ ] Camera shake
* [ ] Visual feedback

---

## Phase 11 — Optimization

* [ ] Object pooling
* [ ] Reduce unnecessary `Instantiate()` / `Destroy()` calls
* [ ] Optimize environment spawning
* [ ] Optimize physics
* [ ] Optimize materials
* [ ] Optimize lighting
* [ ] Profile CPU/GPU performance
* [ ] Test memory usage
* [ ] Test platform-specific performance

---

## Phase 12 — Final Build

* [ ] Gameplay testing
* [ ] Bug fixing
* [ ] Performance testing
* [ ] UI polishing
* [ ] Audio polishing
* [ ] Final balancing
* [ ] Android build
* [ ] iOS build
* [ ] Windows build
* [ ] Linux build
* [ ] macOS build
* [ ] Web build
* [ ] Create release build
* [ ] Update documentation
* [ ] Publish first release

---

# 📈 Future Improvements

Potential future features include:

| Feature                   | Feature                  | Feature            |
| ------------------------- | ------------------------ | ------------------ |
| 🏆 High Scores            | 🌦️ Weather System       | 🌙 Day/Night       |
| 🌧️ Rain                  | 🌫️ Fog                  | 🚦 Traffic         |
| 🚘 Multiple Vehicles      | 🎨 Vehicle Customization | 🛣️ New Roads      |
| 🏔️ Multiple Environments | 🪙 Collectible Types     | ⚡ Power-Ups        |
| 🛡️ Temporary Shields     | ❤️ Health Pickups        | 🔥 Speed Boosts    |
| 📱 Mobile Controls        | 🎮 Controller Support    | 🔊 Advanced Audio  |
| 🌍 Multiple Levels        | 📊 Difficulty Scaling    | ✨ Advanced Effects |

---

# 🧪 Development Philosophy

Hazardaz-Drive will be developed incrementally.

Instead of building the complete game at once, development will follow:

```text
Prototype
    ↓
Core Gameplay
    ↓
Gameplay Systems
    ↓
Content
    ↓
Polishing
    ↓
Optimization
    ↓
Final Build
```

The initial goal is to create a **playable prototype** before adding advanced visuals, effects, content, and optimization.

---

# 📚 Learning Goals

Hazardaz-Drive is also being developed as a practical **Unity and C# learning project**.

Through development, the project will explore:

* C# programming
* Unity GameObjects
* Components
* Transform systems
* Rigidbody physics
* Collision detection
* Prefabs
* Object pooling
* Game-state management
* UI systems
* Event-driven programming
* Script organization
* Reusable game systems
* Game mathematics
* Performance optimization
* Cross-platform development
* Git and GitHub workflow

---

# 🗂️ Project Status

| Category                 | Information                                   |
| ------------------------ | --------------------------------------------- |
| **Development Status**   | 🚧 In Development                             |
| **Current Stage**        | Prototype / Core Systems                      |
| **Unity Version**        | `Unity 6.3 LTS`                               |
| **Programming Language** | `C#`                                          |
| **Target Platforms**     | Android • iOS • Windows • Linux • macOS • Web |


---

# 🤝 Contributions

Hazardaz-Drive is primarily being developed as a personal Unity game-development project.

Suggestions, ideas, improvements, and feedback are welcome.

---

# 📄 License

This project is released under the license specified in the repository's `LICENSE` file.

Third-party assets, models, textures, sounds, and other resources may have their own licenses.

---

# 👨‍💻 Developer

## **Azaf Games**

**Unity Game Development • C# • Game Programming • Interactive Experiences**

---

# ⭐ Project Goal

The ultimate goal of **Hazardaz-Drive** is to transform a simple endless-road concept into a **polished, fast-paced arcade driving experience** while demonstrating practical Unity and C# game-development skills.

```text
        🚗 DRIVE
           ↓
        🪙 COLLECT
           ↓
        🚧 AVOID
           ↓
        ❤️ SURVIVE
           ↓
        🏆 SCORE HIGHER
```

### 🚗 Hazardaz-Drive

> **Drive Further. Survive Longer. Score Higher.**
