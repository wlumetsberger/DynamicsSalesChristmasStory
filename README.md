# Die Weihnachtsgeschichte des Dynamics CRM Sales:

In der eiskalten Nacht des Nordpols stand der Weihnachtsmann vor einer
monumentalen Herausforderung – die Organisation der Geschenkzustellungen
sollte effizienter, fairer und im Einklang mit der verfügbaren Energie
erfolgen. Santa erinnerte sich an das Dynamics CRM Sales System, das er
dieses Jahr eingeführt hatte, um die Verwaltung seiner Geschenke zu
optimieren. Mit dieser Technologie könnte er nicht nur das
Weihnachtsfest retten, sondern auch sicherstellen, dass jedes Kind das
Geschenk bekommt, das es verdient.

## Aufgabe 1: Die Einführung des Energietanks

Die Elfen sind begeistert, der Weihnachtsmann möchte eine neue Entität
namens "Energietank" im Dynamics CRM System einführen. Dieser Tank
sollte die verfügbare Energie für die Geschenke repräsentieren. Erstelle
die Entitäten wie sie benötigt wird um die Anforderungen der anderen
Beispiele umsetzten zu können.

## Aufgabe 2: Manuelle Ergänzung der Kontaktentität

Um den Schlimmheitsgrad (1-100) jedes Kindes direkt in der
Kontaktentität (repräsentiert jeweils ein Kind) zu speichern, soll die
Spalte „Schlimmheitsgrad“ in der Kontaktentität hinzugefügt werden. Es
gilt sicherzustellen, dass diese Spalte korrekt erstellt und für die
Verwendung im System konfiguriert ist, sodass die Elfen für jedes Kind
den Faktor pflegen kann.

## Aufgabe 3: Plugin für die Verkaufschancenbewertung mit dynamischer Energieverteilung:

Die Elfen arbeiteten an einem Plugin, um sicherzustellen, dass die
Energie gerecht auf die Kinder verteilt wird. Das Plugin sollte:

-   Überprüfen, ob die verfügbare Energie im Tank ausreicht, um die
    > Energie für das aktuelle Geschenke abzudecken.

-   Die Energie unter Berücksichtigung den Schlimmheitsfaktor sowie der
    > verfügbaren Energie im Energietank verteilen. Kinder mit wenig
    > Schlimmheitsfaktor sollten das meiste erhalten, während Kinder mit
    > hohem Schlimmheitsfaktor das Wenigste bekommen.

-   Falls die verfügbare Energie nicht ausreicht, um alle Geschenke zu
    > versorgen, sollte die Verkaufschance nur mehr als verloren
    > abgeschlossen werden können.

-   Verkaufschance die als gewonnen abgeschlossen werden erhalten die
    > Energie aus dem Energietank in diesem Schritt. Es muss
    > sichergestellt sein, dass die Energie auch wirklich dem Speicher
    > entzogen worden ist.

-   Ist bei einer Verkaufschance kein Kind (Kontakt) hinterlegt, so kann
    > die Verkaufschance nicht abgeschlossen werden.

-   Wiederspricht im Plugin ein Regelset so soll der Elf eine
    > Fehlermeldung erhalten. Beispiel:  
    > „Leider ist zu wenig Energie vorhanden. Frage Santa ob er noch
    > Energie in den Speicher laden kann“

-   Die Logik zur Validierung könnte wie folgt aussehen:

    -   Wenn eine Verkaufschance als Gewonnen abgeschlossen wird

    -   Prüfe alle offenen Verkaufschancen und deren Energiebedarf

        -   Selektiere Verkaufschancen die aktuell offen sind

        -   Selektiere alle Kinder der Verkaufschancen

        -   Erstelle dir eine Liste die Energiebedarf und
            > Schlimmheitsfaktor beinhält

        -   Wähle so viele wie möglich sind mit dem aktuellen
            > Energiespeicher. Du kannst die Kriterien frei wählen,
            > berücksichtige aber allenfalls Schlimmheitsfaktor und
            > Energiebedarf.

        -   Prüfe ob die aktuelle Verkaufschance enthalten ist.

-   Die Logik zum Abzug der Energie aus dem Speicher:

    -   Sobald die Verkaufschance als Gewonnen abgeschlossen worden ist:

    -   Reduziere den Energiespeicher um die erforderliche Energie

https://github.com/wlumetsberger/DynamicsSalesChristmasStory/tree/master/plugins/Smartpoint.ChristmasStory.Opportunity

## Aufgabe 4: Konsolenanwendung für Santa

Santa benötigte eine Konsolenanwendung, um seinen Energietank manuell
aufzuladen. Eine spezielle Anwendung wird entwickelt, damit Santa den
Energielevel direkt eingeben kann, und der Energietank wird sofort um
den angegebenen Energielevel erhöht.

https://github.com/wlumetsberger/DynamicsSalesChristmasStory/tree/master/apps/SantasEnergieLeveler

## Aufgabe 5: Azure Function für die tägliche Energieaufladung:

Eine Azure Function wird implementiert, um sicherzustellen, dass der
Energietank regelmäßig und automatisch um 10% aufgeladen wird. Diese
Funktion wird einmal pro Tag automatisch ausgeführt, und der Routine-Job
gewährleistete eine konstante Energieversorgung. Santa kann diesen
Prozess nicht beeinflussen, es wurde vom Universum festgelegt.

https://github.com/wlumetsberger/DynamicsSalesChristmasStory/tree/master/az-functions/UniverseEnergyLeveler

Nützliche Links:

[XRM Toolbox](https://www.xrmtoolbox.com/)
  
[Dataverse developer documentation - Power Apps \| Microsoft
Learn](https://learn.microsoft.com/en-us/power-apps/developer/data-platform/)

[Write a plug-in (Microsoft Dataverse) - Power Apps \| Microsoft
Learn](https://learn.microsoft.com/en-us/power-apps/developer/data-platform/write-plug-in)

[Microsoft Power Platform CLI - Power Platform \| Microsoft
Learn](https://learn.microsoft.com/en-us/power-platform/developer/cli/introduction)

[PowerApps-Samples/dataverse/orgsvc/C#-NETCore/ServiceClient at master ·
microsoft/PowerApps-Samples ·
GitHub](https://github.com/microsoft/PowerApps-Samples/tree/master/dataverse/orgsvc/C%23-NETCore/ServiceClient)

[Interacting with Dataverse data from Azure & C#
(vodovnik.com)](https://www.vodovnik.com/2023/01/12/interacting-with-dataverse-data-from-azure-c/)

[GitHub - spectreconsole/spectre.console: A .NET library that makes it
easier to create beautiful console
applications.](https://github.com/spectreconsole/spectre.console)

Mit diesen Aufgaben wird das Dynamics CRM Sales System des
Weihnachtsmanns perfektioniert, um sicherzustellen, dass die Geschenke
rechtzeitig, fair und unter Berücksichtigung der begrenzten Energie
zugestellt werden können. Inmitten dieser technologischen Verbesserungen
könnte Santa Weihnachten retten und jedem Kind das strahlende Lächeln
schenken, das es verdient. Frohe Weihnachten und viel Spaß beim
Programmieren!
