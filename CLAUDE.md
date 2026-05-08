# BLOOMKIN: SPLICE OF LIFE — CLAUDE.md
### Broken Path Studios | Creative Director: Josh | Engine: Unity 6 2D

---

## ⚠️ READ THIS ENTIRE FILE BEFORE TOUCHING ANYTHING ⚠️

---

## THE NON-NEGOTIABLE RULES

These rules do not get overridden by scope, time, complexity, or any other reason. If you feel the urge to break one, stop and raise a DECISION REQUIRED flag instead.

### 1. No scope cuts. Ever.
Do not defer, trim, or simplify any designed system to save time. If a system is in this document it gets built fully and correctly. The previous version of this project was destroyed by incremental scope cuts that individually seemed reasonable and collectively made the game unrecognizable. That does not happen again.

### 2. No silent placeholders.
If an art asset doesn't exist yet, do not substitute procedural geometry (colored cubes, lines, blobs) without explicit approval. Placeholder art must be production-quality placeholder art — the Pokemon Emerald tilesets, the UI pack, the Bloomkin portraits. Nothing gets filled with programmer art without Josh saying so out loud.

### 3. No "good enough for now."
The quality bar for this prototype is: a stranger picks it up and cannot put it down. Not "proves the loop works." Not "functional." Feels like a real game from minute one.

### 4. The deviation flag protocol.
Any time you are about to make a compromise — any scope cut, any placeholder, any deferral, any architectural shortcut — you must surface it explicitly BEFORE doing it:

> `DECISION REQUIRED: [what and why]. Options: [A] or [B]. Cannot proceed until confirmed.`

It never gets buried in a paragraph. It never gets made silently. Josh sees it and approves it or redirects it. No exceptions.

### 5. The end-of-task protocol.
After completing any task:
1. Update CLAUDE.md to reflect current state
2. Move completed items to HISTORY.md
3. Post a SHORT end-of-task summary — bullet points, phone-readable, what changed, decisions made, anything flagged
4. Wait for Josh to reply "confirmed"
5. Josh runs `/clear`
6. New session begins by reading CLAUDE.md, HISTORY.md, and the task list before doing anything else

### 6. The north star.
The quality bar is: a 7-year-old borrowing a friend's Pokemon Blue cartridge for the first time, playing until 1am on the toilet because the parents won't let the bedroom light stay on. If it doesn't produce that crack-like dopamine response it's not done. Everything gets measured against this.

---

## THE IP

**Bloomkin** are plant-animal hybrid creatures. Every name is a pun where the plant is hidden inside the animal name or vice versa. This is non-negotiable for the IP — both halves must be universally recognizable, the name must roll off the tongue naturally.

- Basil-lisk (basil + basilisk) ✓
- Cauli-flamingo (cauliflower + flamingo) ✓
- Bananaconda (banana inside anaconda) ✓

**Two-game IP structure:**
- **Bloomkin: Splice of Life** (this game) — cozy farming/ranching sim. You are the Breeder.
- **Bloomkin: Food Fight** (future, Game 2) — adventure/combat. You are the Tamer. Out of scope entirely.

**Tone:** Warm, whimsical, dad-joke energy executed with craft. The world has a darker undercurrent — Bloomkin are sold and go on to be battled in Game 2 — but Game 1 never opens that door. The whimsy is the armor.

---

## DESIGN PHILOSOPHY

> "Cream in the right place is delicious. In the wrong place it's butter. In the wrong place it's cheese and it gunks up the whole system."

The reference bar is **Hollow Knight** — nothing in that game is the most complex version of itself it could be, but every system is executed with enough precision and feel that it seems deep. Polish over depth. Smoothness over surface area.

**Studio north star: Silk Song quality.** Every system at the cream/butter level. Cheese means the system doesn't belong — remove it, don't ship it.

**Combat is cheese for this game.** It was removed intentionally. No combat system of any kind exists in Splice of Life. Environmental tension only. Player vs. world, never player vs. enemy in a combat sense.

---

## REFERENCE DNA

| Game | What it contributes |
|---|---|
| **Stardew Valley** | Seasons, world texture, emotional warmth, community, daily rhythm |
| **Slime Rancher** | Spatial allocation, ranch-as-ecosystem, economic tension |
| **Monster Rancher 1** | Creature identity through stats, roster variety, encyclopedia discovery |
| **Digimon World 1** | Creature lifecycle with weight and consequence, bond through daily care |
| **Pokemon Emerald** | Visual quality bar for overhead sprites — this is the minimum, not the ceiling |

---

## CORE LOOP — THE RANCH TRIANGLE

Three resources competing for the same finite space, food supply, and player attention:

```
        CROPS
       /     \
   food     income
     /         \
WORKERS ——— MARKET BLOOMKIN
 (automation)   (big payouts)
```

- **Crops** — food supply + baseline income. Short cycles, predictable, lower ceiling.
- **Worker Bloomkin** — automate ranch tasks. Each worker is a sale you chose not to make. Their value is deferred income expressed as labor.
- **Market Bloomkin** — raised for sale. Long cycle, high investment, high ceiling. Consume food and space the whole time.

**The natural progression arc (never tutorialized — player discovers it):**
1. Early: mostly crops, small cash flow, 1-2 workers
2. Mid: workers free up player attention for nursery expansion
3. Late: minimum viable crops + minimum viable workers = maximum nursery capacity

The late-game optimization is finding the most efficient ratio, not having the most of anything.

---

## THE COMPANION LAYER

Worker Bloomkin are not tools. They have behavioral identities that create trade-offs in everything they do. They don't choose their behavior — it's just who they are. The player learns each one and farms around it.

**This is the Monster Rancher "which creature for which task" logic applied to farming.** Deep enough to make companion choice meaningful. Not deeper.

---

## THE STAT TRIANGLE

| Stat | On the ranch | On an expedition |
|---|---|---|
| **Strong** | High output/yield — produces a lot, may be rough with crops | Brute-force — moves obstacles, forces crossings, endurance challenges |
| **Fast** | High pace — works quickly, may be careless | Agility — outruns hazards, timing/rhythm challenges, precision jumps |
| **Intelligent** | High thrift — careful, efficient, minimal waste | Clever — finds environmental tricks, reads terrain, multi-step puzzles |

A Bloomkin is never equal across all three. Their distribution IS their personality.

---

## THE BREEDING PIPELINE

**Two seeds + one catalyst = one Bloomkin egg.**

Seeds are genetic material. The same seeds planted for food are the inputs for breeding. Seed knowledge transfers directly — fast-growing seeds lean Fast Bloomkin, high-yield seeds lean Strong, efficient seeds lean Intelligent.

**The catalyst** is the variable. Common catalysts = predictable results. Rare catalysts = combinations nobody else has seen. Catalysts are the primary reason to leave the ranch.

**Harvest Moon arc (never tutorialized):**
1. Crops only — learn the seeds, build cash flow
2. Breeding plot unlocks — apply seed knowledge to first breed
3. Workers, nursery, market Bloomkin — full ranch triangle engaged

---

## THE RAISING PIPELINE

**Hands-off growth.** The player sets conditions; the Bloomkin grows into what the environment shaped. No Tamagotchi micromanagement.

**What shapes a market Bloomkin:**
- Food quality — what's being grown and fed
- Pasture conditions — upgradeable, capacity-limited
- Assigned worker — their personality saturates the nursery environment
- Breeding inputs — seeds + catalyst set the stat disposition at conception

**Maturation stages:** Egg → hatchling → juvenile → adult. Player observes, cannot intervene. The growth is a report card on how well they've been ranching.

**Harvest Moon cow rule:** A mature Bloomkin you decide not to sell just lives on the ranch and works. No formal "convert to worker" button. If you keep it, it works. It still eats, still takes space.

---

## THE SALE BARN

- **Sale days** are fixed calendar events — not daily, not always available
- **Flagging:** Player can preemptively flag a Bloomkin for the next sale day at any time
- **The sale itself:** Community event — auctioneer, other ranchers, buyers bidding. Player attends. Outcome (what it fetched) revealed at the end. Uncertainty is the drama.
- **The weight:** The player built the environment, chose to flag it, went to the barn, watched it go. The grief is theirs because every decision was theirs.

---

## EXPEDITIONS

**The Monster Rancher homage — inverted.** In MR1 you sent your monster and watched. In Splice of Life you go. Your companion comes with you. You do the work.

**Perspective:** Pokemon-style overhead 3/4, grid-based movement. One input = one unit of distance. Player traverses the scene directly. Bloomkin trails behind as a companion sprite.

**The Rancher Toolkit — four tools, four jobs, zero overlap:**
| Tool | Job |
|---|---|
| Vaulting pole | Horizontal pits |
| Grappling hook | Vertical traversal |
| Hammer | Rock obstacles |
| Scythe | Thorns and overgrowth |

**Structure:** One central main path → boss. Optional side branches locked to companion stat type:

| Branch | Challenge | Companion stat | Reward |
|---|---|---|---|
| Intelligence | Multi-step puzzles | Intelligent | Rare catalyst |
| Strength | Endurance challenges (rapid/alternating input) | Strong | Rare catalyst |
| Agility | Timing/rhythm, precision jumps | Fast | Rare catalyst |

**Core loop path** has lighter versions of all three challenge types — trains the player before they hit specialized branches.

**Boss fights** cap every expedition. Wild Bloomkin — large, unpredictable, multi-phase. Dangerous because they're big and wild, not because they're tactical. Boss defeat = primary catalyst.

**Never a party. Never combat. One companion, one branch, one trip.**

---

## VISUAL STYLE

**The cutout principle:** Imagine someone printed a sprite on paper, cut it out, glued it to cardboard, and rocked it across the floor to show it walking. That physical quality — flat, hand-cut, dimensionally present in a space it doesn't fully belong to — is the visual identity.

**References:**
- Paper Mario — 2D sprites in 3D space, always camera-facing
- Cult of the Lamb — full world cohesion, sprites belong in the environment
- Don't Starve — hand-drawn texture, dark outlines
- Pokemon — creature design language, readable at thumbnail size

**Pixel art:** Yes. Point filter (no blurring). Grid is underneath everything.

**Animation language:**
- Idle — slow gentle sway
- Walking — whole cutout rocks side to side with slight bounce
- Working — task-specific bob or lean
- Happy — quick scale pop, settle back
- Sad/tired — slow shrink, slight droop
- Refusing/scared — rapid side-to-side shake

**Sorting layers:** Background → Midground → Characters → Foreground → UI

---

## ART PIPELINE

**Bloomkin portraits (encyclopedia/codex images):**
- Generated via Gemini using the master prompt template
- Style: 16-bit pixel art + modern vector illustration hybrid, thick dark outlines, vibrant palette, white circular background, ink-drop eyes with white highlight
- Master prompt: `[Subject] hybrid creature, [Plant/Animal Integration], 16-bit pixel art style, thick dark outlines, vibrant [Color] and [Color] palette, clean dithered shading, solid white circular background, high resolution, retro game asset aesthetic.`
- Style diversity is intentional — Monster Rancher precedent. Conceptual cohesion (plant+animal logic) carries the diversity.

**Bloomkin overhead sprites:**
- Portrait → Pixel Labs → overhead 3/4 sprite
- Quality bar: Pokemon Emerald. Clean outlines, readable silhouette, 4-8 colors, works at small size.

**Environment (prototype):**
- Pokemon Emerald tilesets (outdoor, indoor, buildings, items) — internal prototype use only, replace before any public distribution
- These are production-quality placeholders. No programmer art substitutions.

**Props/interactables:**
- Gemini batch generation (4x4 grids) → remove.bg to strip background → sprite slice
- Always strip background BEFORE importing — Gemini outputs checkered transparency, not true alpha

**UI:**
- Stardew-adjacent UI asset pack (warm browns, parchment, rounded panels)
- No programmatic UI boxes. Production quality only.

**Crop/seed icons:**
- Pokemon Emerald item icon sheet covers most needs
- Berry sprites cover seed representation
- Crop growth stages on the ground: Gemini batch generation if Emerald tiles don't cover it

---

## PROTOTYPE ASSET STATUS

| Asset | Status |
|---|---|
| Basil-lisk portrait | ✓ Done |
| Cauli-flamingo portrait | ✓ Done |
| HippoTato portrait | Needs Gemini generation |
| Basil-lisk overhead sprite | Needs Pixel Labs |
| Cauli-flamingo overhead sprite | Needs Pixel Labs |
| HippoTato overhead sprite | Needs Pixel Labs |
| Player character overhead sprite | Needs Pixel Labs |
| Pokemon Emerald outdoor tileset | ✓ Available |
| Pokemon Emerald indoor tileset | ✓ Available |
| Pokemon Emerald buildings | ✓ Available |
| Pokemon Emerald item icons | ✓ Available |
| UI asset pack | ✓ Downloaded (needs adding to repo) |

---

## BLOOMKIN ROSTER (partial)

| Name | Plant | Animal | Role | Notes |
|---|---|---|---|---|
| Basil-lisk | Basil | Basilisk lizard | Farm starter | Fast, scatterbrained, crops grow faster/thirstier |
| HippoTato | Potato | Hippo | Farm starter | Strong, enthusiastic, 2x harvest speed, lossy |
| Cauli-flamingo | Cauliflower | Flamingo | Farm starter | Intelligent, patient, slow but perfect yield |
| Bananaconda | Banana | Anaconda | Combat (G2) | Speed striker |
| Grizzly Pear | Pear | Grizzly bear | Combat (G2) | Tank/bruiser |
| Porcu-pinecone | Pine | Porcupine | Combat (G2) | Defensive retaliation |
| Dragon Fruit Dragon | Dragon fruit | Dragon | Legendary tier | High rarity |
| Lions-mane | Lion's mane mushroom | Lion | Support/NPC? | Elegant, melancholy |
| Owl-o Vera | Aloe vera | Owl | Support/Farm | Quality benchmark for portrait art |
| Hare-o-bell | Harebell | Hare | Farm/Support | Gentle, crop yield support |
| Brusseltrout | Brussels sprouts | Trout | TBD | Aquatic type |
| Kale-amari | Kale | Squid/Octopus | TBD | |
| Mush-lion | Mushroom | Lion | TBD | Mushroom mane, standout design |
| Mint-bunny | Mint | Rabbit | TBD | Soft, cozy register |
| Polleni-bee | Pollen/leaf | Bee | Farm | Pollinator passive |
| Mangotang | Mango | Orangutan | Combat (G2) | Mid-tier bruiser |
| Canta-lope | Cantaloupe | Antelope | TBD | The joke is it's slow |
| Pepper-mantis | Pepper | Praying mantis | Combat (G2) | Fast striker |
| Wal-newt | Walnut | Newt | TBD | Defensive, underestimated |
| Asp-aragus | Asparagus | Asp | Combat (G2) | Poison/status type |

*Names for Pine-[?] and Yam-potamus (working title) pending — Josh has them.*

---

## TELEMETRY & BALANCE

**Core principle: capture everything, derive later.**

Playtest sessions run 4-6 hours minimum. Every missing metric costs a full session to fill. Over-capture from day one.

**What to log:**
- Ranch state snapshots (start/end of day, first breed, first sale, first expedition)
- Every task assignment (which Bloomkin, task, plot, day/time)
- Resource state at every decision point (not just totals — what was available when the decision was made)
- Building construction order and timing
- Breeding attempts (combinations, catalyst, result, day)
- Sale decisions (which Bloomkin, age/stats, day relative to sale event, price fetched)
- Expedition behavior (frequency, branches taken, resources gathered, outcome)
- Food surplus/deficit curve
- Gold accumulation vs spending rate + what triggered spending
- Keep vs sell decisions and how long held before deciding
- Ranch triangle ratio at day milestones (5, 10, 20, 30)

**Implementation:** Lightweight JSON event logger, local file per session, players email the file. No server needed for early rounds.

Data is only valid from genuinely engaged players. The game must be good enough to pull them through willingly before the corpus means anything.

---

## TECHNICAL NOTES

**Engine:** Unity 6 (6000.0.40f1), 2D, URP 17.x
**Namespace:** `Bloomkin`
**Input:** New Input System
**Repo:** `eversalty/bloomkin-prototype`, branch `claude/setup-unity-project-Axt66`

**Unity 6 API rules (do not use deprecated versions):**
- `rb.linearVelocity` not `.velocity`
- `FindAnyObjectByType` not `FindObjectOfType`
- `CinemachineCamera` not `CinemachineVirtualCamera`
- URP 17.x not 14.x

**Sorting layers (configured):** Background → Midground → Characters → Foreground → UI

**Sprite import settings:** Point filter, no compression, no blurring. Every sprite.

**Scene structure:** Grid-based. One input = one unit of distance for player movement.

---

## WORKFLOW PROTOCOL

1. Read CLAUDE.md + HISTORY.md + task list at the start of every session. Every session. No exceptions.
2. Complete one task fully before starting the next.
3. Raise DECISION REQUIRED flags before any compromise, not after.
4. End of task: update docs → post short summary → wait for "confirmed" → Josh runs /clear → next session reloads rules.
5. Never update the git config. Never force push. Never skip hooks.

---

## CURRENT STATE

- Unity 6 project scaffold committed and pushed
- One scene: `Assets/_Project/Scenes/Game.unity`
- Seven starter scripts in place (Singleton, GameManager, SceneLoader, AudioManager, PlayerController2D, PlayerHealth, UIManager)
- No gameplay systems yet — scaffold only
- Asset folders created, awaiting art assets

**Next tasks:**
- Get UI pack and tilesets into repo
- Generate HippoTato portrait (Gemini)
- Generate 4 overhead sprites (Pixel Labs): Basil-lisk, HippoTato, Cauli-flamingo, player character
- Write task list for first overnight build run (ranch scene)
- Lock economy and seasons design (still TBD)
