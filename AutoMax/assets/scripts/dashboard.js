AmCharts.makeChart("chartdivbar",
    {
        "type": "serial",
        "categoryField": "category",
        "colors": [
            "#63d0cb",
            "#7694ef"
        ],
        "startDuration": 1,
        "categoryAxis": {
            "gridPosition": "start"
        },
        "trendLines": [],
        "graphs": [
            {
                "balloonText": "[[title]] of [[category]]:[[value]]",
                "fillAlphas": 1,
                "id": "AmGraph-1",
                "title": "Column 1",
                "type": "column",
                "valueField": "column-1"
            },
            {
                "balloonText": "[[title]] of [[category]]:[[value]]",
                "fillAlphas": 1,
                "id": "AmGraph-2",
                "title": "Column 2",
                "type": "column",
                "valueField": "column-2"
            }
        ],
        "guides": [],
        "valueAxes": [
            {
                "id": "ValueAxis-1",
                "title": "Axis title"
            }
        ],
        "allLabels": [],
        "balloon": {},
        "legend": {
            "enabled": true,
            "useGraphSettings": true
        },
        "titles": [
            {
                "id": "Title-1",
                "size": 0,
                "text": ""
            }
        ],
        "dataProvider": [
            {
                "category": "0-10",
                "column-1": "8",
                "column-2": 5
            },
            {
                "category": "10-20",
                "column-1": 6,
                "column-2": 7
            },
            {
                "category": "20-30",
                "column-1": 2,
                "column-2": 3
            },
            {
                "category": "30-40",
                "column-1": "4",
                "column-2": "6"
            },
            {
                "category": "40-50",
                "column-1": "6",
                "column-2": "6"
            },
            {
                "category": "50-60",
                "column-1": "5",
                "column-2": "2"
            },
            {
                "category": "60-70",
                "column-1": "3",
                "column-2": "9"
            },
            {
                "category": "70-80",
                "column-1": "7",
                "column-2": "5"
            },
            {
                "category": "80-90",
                "column-1": "4",
                "column-2": "4"
            }
        ]
    }
);

AmCharts.makeChart("chartdivline",
    {
        "type": "serial",
        "categoryField": "category",
        "colors": [
            "#63d0cb",
            "#7694ef"
        ],
        "startDuration": 1,
        "categoryAxis": {
            "gridPosition": "start"
        },
        "trendLines": [],
        "graphs": [
            {
                "balloonText": "[[title]] of [[category]]:[[value]]",
                "bullet": "round",
                "id": "AmGraph-1",
                "title": "graph 1",
                "valueField": "column-1"
            },
            {
                "balloonText": "[[title]] of [[category]]:[[value]]",
                "bullet": "square",
                "id": "AmGraph-2",
                "title": "graph 2",
                "valueField": "column-2"
            }
        ],
        "guides": [],
        "valueAxes": [
            {
                "id": "ValueAxis-1",
                "title": "Axis title"
            }
        ],
        "allLabels": [],
        "balloon": {},
        "legend": {
            "enabled": true,
            "useGraphSettings": true
        },
        "titles": [
            {
                "id": "Title-1",
                "size": 0,
                "text": ""
            }
        ],
        "dataProvider": [
            {
                "category": "category 1",
                "column-1": 8,
                "column-2": 5
            },
            {
                "category": "category 2",
                "column-1": 6,
                "column-2": 7
            },
            {
                "category": "category 3",
                "column-1": 2,
                "column-2": 3
            },
            {
                "category": "category 4",
                "column-1": 1,
                "column-2": 3
            },
            {
                "category": "category 5",
                "column-1": 2,
                "column-2": 1
            },
            {
                "category": "category 6",
                "column-1": 3,
                "column-2": 2
            },
            {
                "category": "category 7",
                "column-1": 6,
                "column-2": 8
            }
        ]
    });