var projectsJsonData;
let mymap;
$(function () {
  //Load Map
  mymap= L.map("mapView").setView([30.033333, 31.233334], 13);
  L.tileLayer(
    "https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token=pk.eyJ1IjoibW9zdGFmYWFiZGVscmFobWFuIiwiYSI6ImNqd2h4a2FpMDBqeHc0Ym41bG9vc2Uyc20ifQ.hSU-ewch930GLP88NNC3Kg",
    {
      attribution:
        'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
      maxZoom: 18,
      id: "mapbox/streets-v11",
      tileSize: 512,
      zoomOffset: -1,
   
    }
  ).addTo(mymap);

  //Render Rable
  RenderTable();
//   var popup = L.popup();

//   function onMapClick(e) {
//       popup
//           .setLatLng(e.latlng)
//           .setContent("You clicked the map at " + e.latlng.toString())
//           .openOn(mymap);
//   }
  
//   mymap.on('click', onMapClick);
  //end of main function
});

function RenderTable() {
  $.ajax({
    url: "http://centricadmin-001-site1.htempurl.com/api/projects",
    type: "GET",
    dataType: "json",
    success: function (data) {
      projectsJsonData = data;

      console.log(projectsJsonData);

      var tableBody = $("#tbody");
      if (projectsJsonData) {
         
        for (let i = 0; i < projectsJsonData.length; i++) {
          let project = projectsJsonData[i];
          //Add Markers on Map
          var marker = L.marker([project["xCoordinate"], project["yCoordinate"]]).addTo(mymap);
          marker.bindPopup(project["name"])
          //Add Data to Table
          var tr = "<tr>";
          tr += "<td>" + project["name"] + "</td>";
          tr += "<td>" + project["adminstratorId"] + "</td>";
          tr += "<td>" + project["cityId"] + "</td>";
          tr += "<td>" + project["areaId"] + "</td>";
          tr += "<td>" + project["budget"] + "</td>";
          tr += "<td>" + project["statusId"] + "</td>";
          tr += "<td>" + project["startDate"] + "</td>";
          tr += "<td>" + project["endDate"] + "</td>";
          tr += "</tr>";
          tableBody.append(tr);
        }
      }
   
    
      $("#table").DataTable({
        paging: true,
        lengthChange: false,
        searching: false,
        ordering: true,
        info: true,
        autoWidth: true,
      });
    },
    error: function (request, error) {
      alert("Request: " + JSON.stringify(request));
    },
  });
}

// function AddRowsToHRMLFromJSON() {
//   var tableBody = $("#tbody");
//   if (projectsJsonData) {
//     // JSON data not null
//     for (let i = 0; i < projectsJsonData.length; i++) {
//       let project = projectsJsonData[i];
//       console.log(project);
//       // let tr = "<tr>";
//       // tr+"<td>"+project["name"]+ "</td>";
//       // tr+"<td>"+project["adminstratorId"]+ "</td>";
//       // tr+"<td>"+project["cityId"]+ "</td>";
//       // tr+"<td>"+project["areaId"]+ "</td>";
//       // tr+"<td>"+project["budget"]+ "</td>";
//       // tr+"<td>"+project["statusId"]+ "</td>";
//       // tr+"<td>"+project["startDate"]+ "</td>";
//       // tr+"<td>"+project["endDate"]+ "</td>";
//       // tr+"</tr>"
//       // tableBody.append(tr)
//     }
//   }
// }
