function CustomMarker(latlng, map, args) {
	this.latlng = latlng;	
	this.args = args;	
	this.setMap(map);	
}

CustomMarker.prototype = new google.maps.OverlayView();

CustomMarker.prototype.draw = function() {
	
	var self = this;
	
	var div = this.div;
	
	if (!div) {
	
		div = this.div = document.createElement('div');
		
		if (typeof(self.args.marker_id) !== 'undefined') {
			div.dataset.marker_id = self.args.marker_id;
		}
		
		if (typeof (self.args.opis) !== 'undefined') {
		    div.dataset.opis = self.args.opis;
		}

		if (typeof (self.args.slika) !== 'undefined') {
		    div.dataset.slika = self.args.slika;
		}

		if (typeof (self.args.ime) !== 'undefined') {
		    div.dataset.ime = self.args.ime;
		}
		if (typeof (self.args.prezime) !== 'undefined') {
		    div.dataset.prezime = self.args.prezime;
		}
		if (typeof (self.args.stanje) !== 'undefined') {
		    div.dataset.stanje = self.args.stanje;
		}

		if (self.args.stanje == 0) {
		    div.className = 'pin prijavljeno';
		    div.attributes.class = "pin prijavljeno";

		}
		else {
		    div.className = 'pin preuzeto';
		    div.attributes.class = "pin preuzeto";
		}

		google.maps.event.addDomListener(div, "click", function (event) {
		    $('.modal-title').text(self.args.opis);
		    $('.opisSlika').attr('src', self.args.slika);
		    $('.markerId').val(self.args.marker_id);
		    $('.korisnik').text(self.args.ime+" "+self.args.prezime);
		    if (self.args.stanje == 1) {
		        $("#ContentPlaceHolder1_BtnPromijeniStanje").prop('value', "Završi");
		    }
		    else {
		        $("#ContentPlaceHolder1_BtnPromijeniStanje").prop('value', 'Preuzmi')
		    }
		    $('#prikazModal').modal('show');
		    //dodati ime i prezime u ovaj popup
		    //mozda i datum
			google.maps.event.trigger(self, "click");
		});
		
		var panes = this.getPanes();
		panes.overlayImage.appendChild(div);
	}
	
	var point = this.getProjection().fromLatLngToDivPixel(this.latlng);
	
	if (point) {
		div.style.left = (point.x - 10) + 'px';
		div.style.top = (point.y - 20) + 'px';
	}
};

CustomMarker.prototype.remove = function() {
	if (this.div) {
		this.div.parentNode.removeChild(this.div);
		this.div = null;
	}	
};

CustomMarker.prototype.getPosition = function() {
	return this.latlng;	
};