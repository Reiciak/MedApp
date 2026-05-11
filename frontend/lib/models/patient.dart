class Patient {
  final String? id;
  final String? name;
  final String? surname;

  Patient({
    this.id, 
    required this.name, 
    required this.surname
    });

  factory Patient.fromJson(Map<String, dynamic> json) {
    return Patient(
      id: json['id']?.toString(),
      name: json['name']?.toString(),
      surname: json['surname']?.toString(),
    );
  }

  Map<String, dynamic> toJson() {
    return {'id': id, 'name': name, 'surname': surname};
  }
}
