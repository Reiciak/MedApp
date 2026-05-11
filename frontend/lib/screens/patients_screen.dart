import 'package:flutter/material.dart';
import '../services/api_service.dart';
import '../models/patient.dart';

class PatientsScreen extends StatefulWidget {
  const PatientsScreen({super.key});

  @override
  State<PatientsScreen> createState() => _PatientsScreenState();
}

class _PatientsScreenState extends State<PatientsScreen> {
  final ApiService _apiService = ApiService();
  List<Patient> _patients = [];

  @override
  void initState() {
    super.initState();
    _fetchPatients();
  }

  Future<void> _fetchPatients() async {
    try {
      final patients = await _apiService.getPatients();
      setState(() {
        _patients = patients;
      });
    } catch (e) {
      print('Error fetching patients: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Patients')),
      body: Center(
        child: _patients.isEmpty
            ? CircularProgressIndicator()
            : ListView.builder(
                itemCount: _patients.length,
                itemBuilder: (context, index) {
                  final patient = _patients[index];
                  return ListTile(
                    title: Text('${patient.name} ${patient.surname}'),
                    subtitle: Text('ID: ${patient.id ?? '-'}'),
                  );
                },
              ),
      ),
    );
  }
}
