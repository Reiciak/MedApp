import 'dart:convert';
import 'package:frontend/models/results.dart';

import '../models/patient.dart';
import 'package:http/http.dart' as http;

class ApiService {
  static const String baseUrl = 'http://localhost:5000';
  static const String patientsEndpoint = '$baseUrl/api/patients';
  static const String resultsEndpoint = '$baseUrl/api/results';

  Future<List<Patient>> getPatients() async {
    try {
      final response = await http.get(Uri.parse(patientsEndpoint));

      if (response.statusCode == 200) {
        final List<dynamic> data = jsonDecode(response.body);
        return data.map((json) => Patient.fromJson(json)).toList();
      }
      if (response.statusCode == 404) {
        throw Exception('Endpoint Patients not found');
      } else {
        throw Exception('Failed to load patients');
      }
    } catch (e) {
      print('Error fetching patients: $e');
      rethrow;
    }
  }

  Future<List<Result>> getResults() async {
    try {
      final response = await http.get(Uri.parse(resultsEndpoint));

      if (response.statusCode == 200) {
        final List<dynamic> data = jsonDecode(response.body);
        return data.map((json) => Result.fromJson(json)).toList();
      }
      if (response.statusCode == 404) {
        throw Exception('Endpoint result not found');
      } else {
        throw Exception('Failed to load results');
      }
    } catch (e) {
      print('Error fetching results: $e');
      rethrow;
    }
  }
}
