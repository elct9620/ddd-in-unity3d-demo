Domain-Driven Design in Unity3D (Demo)
===

這是一個試驗性的專案，用於驗證 Unity3D 中應用 Domain-Driven Design 的概念是可行的。

## 概念

Domain-Driven Design 採取了分層式架構（Layered Architecture）已經能很好的分離「商業邏輯」和「介面呈現」的問題，這個專案加入了 Clean Architecture 的概念讓整體更清晰。

* `Domain` - 商業邏輯，處理核心的任務
* `UseCase` - 使用流程，負責把商業邏輯組合成可以使用的動作（如：攻擊敵人）
* `Repository` - 資料處理，用來支援 `UseCase` 可以讀取、儲存資料（並能根據需求改變來源）
* `Result` + `UI` - 介面呈現，將 `UseCase` 操作結果封裝成介面所需的資訊反應在畫面上

## 架構

以下皆為 `Assets` 目錄下的檔案。

| 目錄                          | 說明                                                          |
|-------------------------------|---------------------------------------------------------------|
| `BattleSystem`                | 戰鬥系統，為了配合 Test Runner 的 Assembly 需求獨立為一個目錄 |
| `BattleSystem/Domain`         | 商業邏輯，主要放置戰鬥系統的資料保存、判斷邏輯                |
| `BattleSystem/Domain/Service` | 商業邏輯，因為處理邏輯的部分跟資料無關，因此獨立出來          |
| `BattleSystem/UseCase`        | 實際使用的流程，會組合 `Domain` 下的物件使用（如：攻擊敵人）  |
| `BattleSystem/Result`         | `UseCase` 的結果，需要為純資料（Data Transfer Object)         |
| `BattleSystem/Repository`     | 儲存倉庫，用於處理資料的保存                                  |
| `Scene`                       | 各場景的管理程序，用於呼叫各項系統運作並分配到 UI 上          |
| `UI`                          | 介面呈現的邏輯（如：HP 歸零時顯示為紅字）                     |
| `Tests`                       | 測試，只針對每個系統做測試（不依賴 Unity3D）                  |
| `Game.cs`                     | 遊戲主系統，用於簡易的 IoC 容器                               |

> 這裡為了簡化實作因此沒有用於輸入 `UseCase` 的物件類型

### 依賴關係

| 模組                          | 依賴                                                 |
|-------------------------------|------------------------------------------------------|
| `BattleSystem.UseCase`        | `BattleSystem.Domain`, `BattleSystem.Domain.Service` |
| `BattleSystem.Domain.Service` | `BattleSystem.Domain`                                |
| `BattleSystem.Repository`     | `BattleSystem.Domain`                                |
| `Scene`                       | `BattleSystem.UseCase`, `BattleSystem.Result`        |

> `BattleSystem.UseCase` 不依賴 `BattleSystem.Repository` 的原因是因為定義了 `IBattleRepository` 介面。

## 領域模型（Domain Model）

### Value

| 物件    | 說明                                                     |
|---------|----------------------------------------------------------|
| `Actor` | 參與戰鬥的角色，因為簡化設計的關係只記錄生命值跟生存狀態 |

### Entity

| 物件     | 說明                                 |
|----------|--------------------------------------|
| `Battle` | 一場戰鬥的單位，管理玩家跟敵人的互動 |

### Service

| 物件                 | 說明                                   |
|----------------------|----------------------------------------|
| `DamageCalculator`   | 用於計算可套用的傷害，目前只有直接傷害 |
| `RecoveryCalculator` | 用於計算可回復的生命，目前只有直接回復 |

> 另一種做法是實作 `AttackService` 直接呼叫 `Battle` 處理，在流程比較複雜時會沒那麼繁瑣。
