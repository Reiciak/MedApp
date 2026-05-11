import 'package:flutter/material.dart';
import '../services/api_service.dart';
import '../models/results.dart';

class ResultsScreen extends StatefulWidget {
  const ResultsScreen({super.key});

  @override
  State<ResultsScreen> createState() => _ResultsScreenState();
}

class _ResultsScreenState extends State<ResultsScreen> {
  final ApiService _apiService = ApiService();
  List<Result> _results = [];

  @override
  void initState() {
    super.initState();
    _fetchresults();
  }

  Future<void> _fetchresults() async {
    try {
      final results = await _apiService.getResults();

      setState(() {
        _results = results;
      });
    } catch (e) {
      print('Error fetching results: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        centerTitle: true,
        title: const Text(
          'Results',
          style: TextStyle(fontWeight: FontWeight.bold),
        ),
      ),
      body: _results.isEmpty
          ? const Center(child: CircularProgressIndicator())
          : ListView.builder(
              padding: const EdgeInsets.all(12),
              itemCount: _results.length,
              itemBuilder: (context, index) {
                final result = _results[index];
                final isAboveThreshold = (result.resultValue ?? 0) > 100;

                return Padding(
                  padding: const EdgeInsets.only(bottom: 10),
                  child: Container(
                    decoration: BoxDecoration(
                      color: isAboveThreshold
                          ? const Color(0xFFFFEBEE)
                          : Colors.white,
                      borderRadius: BorderRadius.circular(14),
                      border: Border.all(
                        color: isAboveThreshold
                            ? Colors.red.shade300
                            : Colors.grey.shade300,
                        width: isAboveThreshold ? 1.4 : 1,
                      ),
                      boxShadow: [
                        BoxShadow(
                          color: isAboveThreshold
                              ? const Color(0x22D32F2F)
                              : const Color(0x14000000),
                          blurRadius: 8,
                          offset: Offset(0, 3),
                        ),
                      ],
                    ),
                    child: ListTile(
                      contentPadding: const EdgeInsets.symmetric(
                        horizontal: 16,
                        vertical: 10,
                      ),
                      title: Text(
                        result.testName ?? '-',
                        style: const TextStyle(
                          fontWeight: FontWeight.w600,
                          fontSize: 16,
                        ),
                      ),
                      subtitle: Padding(
                        padding: const EdgeInsets.only(top: 6),
                        child: Text(
                          'Wynik: ${result.resultValue ?? '-'}\nSkala: ${result.scale ?? '-'}',
                          style: const TextStyle(height: 1.4),
                        ),
                      ),
                    ),
                  ),
                );
              },
            ),
    );
  }
}
