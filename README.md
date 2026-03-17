<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8" />
<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
<title>meat-control-console — README</title>
<link href="https://fonts.googleapis.com/css2?family=IBM+Plex+Mono:wght@400;500;600&family=Syne:wght@400;600;700;800&display=swap" rel="stylesheet"/>
<style>
  *, *::before, *::after { box-sizing: border-box; margin: 0; padding: 0; }

  :root {
    --bg: #0d0d0d;
    --surface: #141414;
    --border: #2a2a2a;
    --accent: #e05c2a;
    --accent2: #f0a04a;
    --text: #d4cfc9;
    --muted: #666;
    --code-bg: #1a1a1a;
    --tab-active: #1e1e1e;
  }

  body {
    background: var(--bg);
    color: var(--text);
    font-family: 'Syne', sans-serif;
    min-height: 100vh;
    display: flex;
    flex-direction: column;
    align-items: center;
    padding: 40px 16px;
  }

  /* Header */
  .header {
    width: 100%;
    max-width: 820px;
    margin-bottom: 40px;
    animation: fadeDown 0.6s ease both;
  }

  .header-top {
    display: flex;
    align-items: center;
    gap: 14px;
    margin-bottom: 10px;
  }

  .icon {
    width: 46px;
    height: 46px;
    background: var(--accent);
    border-radius: 8px;
    display: flex;
    align-items: center;
    justify-content: center;
    font-size: 22px;
    flex-shrink: 0;
  }

  h1 {
    font-size: 28px;
    font-weight: 800;
    letter-spacing: -0.5px;
    color: #fff;
  }

  h1 span { color: var(--accent); }

  .subtitle {
    font-family: 'IBM Plex Mono', monospace;
    font-size: 12px;
    color: var(--muted);
    margin-top: 6px;
    letter-spacing: 0.04em;
  }

  .badges {
    display: flex;
    gap: 8px;
    flex-wrap: wrap;
    margin-top: 14px;
  }

  .badge {
    font-family: 'IBM Plex Mono', monospace;
    font-size: 11px;
    padding: 3px 10px;
    border-radius: 4px;
    border: 1px solid var(--border);
    color: var(--muted);
  }

  .badge.orange { border-color: var(--accent); color: var(--accent); }
  .badge.gold { border-color: var(--accent2); color: var(--accent2); }

  /* Tabs */
  .tabs {
    width: 100%;
    max-width: 820px;
    animation: fadeDown 0.6s 0.1s ease both;
  }

  .tab-bar {
    display: flex;
    gap: 2px;
    border-bottom: 1px solid var(--border);
    overflow-x: auto;
    scrollbar-width: none;
  }

  .tab-bar::-webkit-scrollbar { display: none; }

  .tab {
    font-family: 'IBM Plex Mono', monospace;
    font-size: 12px;
    padding: 10px 18px;
    background: none;
    border: none;
    border-bottom: 2px solid transparent;
    color: var(--muted);
    cursor: pointer;
    white-space: nowrap;
    transition: color 0.2s, border-color 0.2s;
    margin-bottom: -1px;
  }

  .tab:hover { color: var(--text); }
  .tab.active { color: var(--accent); border-bottom-color: var(--accent); }

  /* Content */
  .content {
    width: 100%;
    max-width: 820px;
    background: var(--surface);
    border: 1px solid var(--border);
    border-top: none;
    border-radius: 0 0 10px 10px;
    padding: 36px 40px;
    min-height: 340px;
    animation: fadeUp 0.3s ease both;
  }

  .panel { display: none; }
  .panel.active { display: block; }

  h2 {
    font-size: 20px;
    font-weight: 700;
    color: #fff;
    margin-bottom: 14px;
    padding-bottom: 10px;
    border-bottom: 1px solid var(--border);
  }

  h3 {
    font-size: 14px;
    font-weight: 600;
    color: var(--accent2);
    margin: 22px 0 8px;
    text-transform: uppercase;
    letter-spacing: 0.08em;
  }

  p {
    font-size: 15px;
    line-height: 1.75;
    color: var(--text);
    margin-bottom: 12px;
  }

  ul {
    list-style: none;
    padding: 0;
    margin-bottom: 12px;
  }

  ul li {
    font-size: 14px;
    line-height: 1.7;
    color: var(--text);
    padding-left: 18px;
    position: relative;
    margin-bottom: 4px;
  }

  ul li::before {
    content: '›';
    position: absolute;
    left: 0;
    color: var(--accent);
    font-weight: 700;
  }

  code {
    font-family: 'IBM Plex Mono', monospace;
    font-size: 12.5px;
    background: var(--code-bg);
    border: 1px solid var(--border);
    padding: 2px 6px;
    border-radius: 4px;
    color: var(--accent2);
  }

  pre {
    background: var(--code-bg);
    border: 1px solid var(--border);
    border-radius: 8px;
    padding: 20px 24px;
    overflow-x: auto;
    margin: 16px 0;
  }

  pre code {
    background: none;
    border: none;
    padding: 0;
    font-size: 13px;
    color: #c9c0b5;
    line-height: 1.7;
  }

  /* Architecture grid */
  .arch-grid {
    display: grid;
    grid-template-columns: repeat(auto-fill, minmax(180px, 1fr));
    gap: 12px;
    margin: 16px 0;
  }

  .arch-card {
    background: var(--code-bg);
    border: 1px solid var(--border);
    border-radius: 8px;
    padding: 16px;
    transition: border-color 0.2s;
  }

  .arch-card:hover { border-color: var(--accent); }

  .arch-card .layer {
    font-family: 'IBM Plex Mono', monospace;
    font-size: 11px;
    color: var(--accent);
    text-transform: uppercase;
    letter-spacing: 0.1em;
    margin-bottom: 6px;
  }

  .arch-card .name {
    font-size: 14px;
    font-weight: 600;
    color: #fff;
    margin-bottom: 4px;
  }

  .arch-card .desc {
    font-size: 12px;
    color: var(--muted);
    line-height: 1.5;
  }

  /* Highlight box */
  .highlight-box {
    background: #1a1208;
    border: 1px solid #3d2a10;
    border-left: 3px solid var(--accent);
    border-radius: 6px;
    padding: 14px 18px;
    margin: 16px 0;
    font-size: 14px;
    line-height: 1.7;
    color: #c8b99a;
  }

  /* Animations */
  @keyframes fadeDown {
    from { opacity: 0; transform: translateY(-12px); }
    to   { opacity: 1; transform: translateY(0); }
  }

  @keyframes fadeUp {
    from { opacity: 0; transform: translateY(8px); }
    to   { opacity: 1; transform: translateY(0); }
  }

  /* Footer */
  .footer {
    margin-top: 28px;
    font-family: 'IBM Plex Mono', monospace;
    font-size: 11px;
    color: var(--muted);
    text-align: center;
  }

  .footer a { color: var(--accent); text-decoration: none; }
</style>
</head>
<body>

<div class="header">
  <div class="header-top">
    <div class="icon">🥩</div>
    <div>
      <h1><span>meat</span>-control-console</h1>
      <div class="subtitle">github.com/GuilhermeCristaldoDev/meat-control-console</div>
    </div>
  </div>
  <div class="badges">
    <span class="badge orange">C# .NET</span>
    <span class="badge">Console App</span>
    <span class="badge gold">Layered Architecture</span>
    <span class="badge">TXT Persistence</span>
    <span class="badge">Real-world project</span>
  </div>
</div>

<div class="tabs">
  <div class="tab-bar">
    <button class="tab active" onclick="switchTab('overview', this)">Overview</button>
    <button class="tab" onclick="switchTab('features', this)">Features</button>
    <button class="tab" onclick="switchTab('architecture', this)">Architecture</button>
    <button class="tab" onclick="switchTab('getting-started', this)">Getting Started</button>
    <button class="tab" onclick="switchTab('tech', this)">Tech Stack</button>
    <button class="tab" onclick="switchTab('author', this)">Author</button>
  </div>

  <div class="content">

    <!-- OVERVIEW -->
    <div class="panel active" id="panel-overview">
      <h2>Overview</h2>
      <p>
        <strong style="color:#fff">meat-control-console</strong> is a C# console application built to manage daily operations of a real meat business. It handles the registration, editing, and daily tracking of meat cuts — with all data persisted locally via structured TXT files.
      </p>
      <p>
        This isn't a toy project. It was designed to solve a real problem, is actively used in production, and was built with layered architecture and SOLID principles from the ground up.
      </p>

      <div class="highlight-box">
        💡 Each session is saved to <code>Documents/MeatConsole/session_yyyy-MM-dd.txt</code>, keeping a clean daily record of every operation performed.
      </div>

      <h3>What it does</h3>
      <ul>
        <li>Register and manage meat cuts with name, price (decimal precision), and unit</li>
        <li>Edit existing entries and delete records</li>
        <li>List all registered cuts in a formatted view</li>
        <li>Persist all data automatically to TXT on every operation</li>
        <li>Load saved data on startup from the last session file</li>
      </ul>
    </div>

    <!-- FEATURES -->
    <div class="panel" id="panel-features">
      <h2>Features</h2>

      <h3>Core CRUD</h3>
      <ul>
        <li>Create new meat cuts with validation</li>
        <li>Read and list all current entries</li>
        <li>Update name, price, or unit of any cut</li>
        <li>Delete cuts by ID with existence check</li>
      </ul>

      <h3>Persistence</h3>
      <ul>
        <li>Daily TXT files stored in <code>Documents/MeatConsole/</code></li>
        <li>File path resolved dynamically — no hardcoding</li>
        <li>Data loaded on startup, saved on every write operation</li>
      </ul>

      <h3>Engineering highlights</h3>
      <ul>
        <li>Interface-based repository pattern (<code>IMeatRepository</code>)</li>
        <li>Manual dependency injection via constructor</li>
        <li>Generic parsing with <code>IParsable&lt;T&gt;</code> for type-safe deserialization</li>
        <li>Separation of concerns across Entities, Repositories, Services, and Utils</li>
        <li>Decimal pricing — no floating-point precision issues</li>
      </ul>
    </div>

    <!-- ARCHITECTURE -->
    <div class="panel" id="panel-architecture">
      <h2>Architecture</h2>
      <p>The project follows a layered structure with clear separation between concerns:</p>

      <div class="arch-grid">
        <div class="arch-card">
          <div class="layer">Layer</div>
          <div class="name">Entities</div>
          <div class="desc">Domain models: <code>MeatCut</code>, <code>MeatSummary</code> with proper encapsulation</div>
        </div>
        <div class="arch-card">
          <div class="layer">Layer</div>
          <div class="name">Repositories</div>
          <div class="desc">Data access via <code>IMeatRepository</code> — decoupled from business logic</div>
        </div>
        <div class="arch-card">
          <div class="layer">Layer</div>
          <div class="name">Services</div>
          <div class="desc">Business rules, orchestration, and workflow between repository and UI</div>
        </div>
        <div class="arch-card">
          <div class="layer">Layer</div>
          <div class="name">Utils</div>
          <div class="desc">Helpers for file I/O, formatting, and shared cross-layer utilities</div>
        </div>
      </div>

      <h3>Key design decisions</h3>
      <ul>
        <li>Repository abstracted behind <code>IMeatRepository</code> — swappable without touching services</li>
        <li>Dependency injection applied manually through constructors, not a framework</li>
        <li><code>IParsable&lt;T&gt;</code> used for type-safe parsing of stored data</li>
        <li>All properties properly encapsulated (private setters where appropriate)</li>
        <li><code>decimal</code> used for prices throughout — never <code>double</code></li>
      </ul>
    </div>

    <!-- GETTING STARTED -->
    <div class="panel" id="panel-getting-started">
      <h2>Getting Started</h2>

      <h3>Prerequisites</h3>
      <ul>
        <li>.NET SDK 8.0 or higher</li>
        <li>Any terminal (Windows, Linux, macOS)</li>
      </ul>

      <h3>Clone & Run</h3>
      <pre><code>git clone https://github.com/GuilhermeCristaldoDev/meat-control-console.git
cd meat-control-console
dotnet run</code></pre>

      <h3>Where data is stored</h3>
      <p>On first run, the app automatically creates the directory and session file:</p>
      <pre><code>C:\Users\{YourUser}\Documents\MeatConsole\session_2025-06-01.txt</code></pre>

      <div class="highlight-box">
        Each day generates a new session file. All records from the previous session are loaded automatically on startup.
      </div>
    </div>

    <!-- TECH STACK -->
    <div class="panel" id="panel-tech">
      <h2>Tech Stack</h2>

      <h3>Language & Runtime</h3>
      <ul>
        <li>C# — primary language</li>
        <li>.NET 8 — runtime and SDK</li>
      </ul>

      <h3>Concepts applied</h3>
      <ul>
        <li>Object-oriented design with interfaces and abstraction</li>
        <li>Generic types and <code>IParsable&lt;T&gt;</code> for type-safe deserialization</li>
        <li>LINQ for data querying and filtering</li>
        <li>File I/O with <code>StreamReader</code> / <code>StreamWriter</code></li>
        <li>Dependency injection (manual, constructor-based)</li>
        <li>Separation of concerns across layers</li>
        <li>Decimal arithmetic for financial precision</li>
      </ul>

      <h3>No external dependencies</h3>
      <p>Fully self-contained. No NuGet packages, no frameworks beyond the .NET base class library.</p>
    </div>

    <!-- AUTHOR -->
    <div class="panel" id="panel-author">
      <h2>Author</h2>
      <p>
        Built by <strong style="color:#fff">Guilherme Cristaldo</strong> — Systems Analysis and Development student, IT support professional, and aspiring back-end developer.
      </p>
      <p>
        This project was created to solve a real operational need in my family's meat business, and to practice clean architecture with C# outside of tutorials.
      </p>

      <h3>Currently working with</h3>
      <ul>
        <li>C# / .NET — core focus</li>
        <li>ASP.NET Core — next step (building a REST API for my workplace)</li>
        <li>Layered architecture and SOLID principles</li>
      </ul>

      <h3>Links</h3>
      <ul>
        <li>GitHub: <code>github.com/GuilhermeCristaldoDev</code></li>
        <li>LinkedIn: <code>linkedin.com/in/guilherme-cristaldo</code></li>
      </ul>
    </div>

  </div><!-- .content -->
</div><!-- .tabs -->

<div class="footer">
  readme viewer · meat-control-console · <a href="https://github.com/GuilhermeCristaldoDev/meat-control-console" target="_blank">view on github ↗</a>
</div>

<script>
  function switchTab(id, btn) {
    document.querySelectorAll('.panel').forEach(p => p.classList.remove('active'));
    document.querySelectorAll('.tab').forEach(t => t.classList.remove('active'));
    document.getElementById('panel-' + id).classList.add('active');
    btn.classList.add('active');

    // re-trigger fade animation
    const content = document.querySelector('.content');
    content.style.animation = 'none';
    content.offsetHeight; // reflow
    content.style.animation = 'fadeUp 0.25s ease both';
  }
</script>
</body>
</html>
