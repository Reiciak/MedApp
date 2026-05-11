class Result {
  final String? id;
  final String? patientId;
  final String? testName;
  final double? resultValue;
  final String? scale;

  Result({
    this.id,
    required this.patientId,
    required this.testName,
    required this.resultValue,
    required this.scale,
  });

  factory Result.fromJson(Map<String, dynamic> json) {
    return Result(
      id: json['id']?.toString(),
      patientId: json['patientId']?.toString(),
      testName: json['testName']?.toString(),
      resultValue: (json['resultValue'] as num?)?.toDouble(),
      scale: json['scale']?.toString(),
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'id': id,
      'patientId': patientId,
      'testName': testName,
      'resultValue': resultValue,
      'scale': scale,
    };
  }
}
