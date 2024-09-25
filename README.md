# CleanUpTMP

CleanUpTMP is a command-line utility designed to delete temporary files (`.tmp`) from specified directories based on the last access time. The program allows you to customize how long a file has not been used and whether to scan subdirectories.

## Features

- Delete `.tmp` files based on their last access time.
- Customizable duration formats: days (d), weeks (w), months (m), and years (y).
- Option to scan subdirectories for temporary files.
  
## Usage

To run CleanUpTMP, use the following command structure:

```bash
CleanUpTMP.exe <directory_path> <duration> [scan_subdirectories]
```

### Parameters

- **`<directory_path>`**: The path to the directory where temporary files will be deleted.
- **`<duration>`**: The time duration that specifies how long a file has not been accessed. The format should be a number followed by a unit:
  - `d` for days
  - `w` for weeks
  - `m` for months
  - `y` for years
- **`[scan_subdirectories]`**: Optional parameter to specify whether to include subdirectories. Use `true` or `false`.

### Examples

1. **Delete temporary files not accessed in the last 15 days (without scanning subdirectories)**:
   ```bash
   CleanUpTMP.exe "C:\temp" 15d
   ```

2. **Delete temporary files not accessed in the last 4 weeks (including subdirectories)**:
   ```bash
   CleanUpTMP.exe "C:\temp" 4w true
   ```

3. **Delete temporary files not accessed in the last 2 months (without scanning subdirectories)**:
   ```bash
   CleanUpTMP.exe "C:\temp" 2m
   ```

4. **Delete temporary files not accessed in the last 1 year (including subdirectories)**:
   ```bash
   CleanUpTMP.exe "C:\temp" 1y true
   ```

## Error Handling

- If the specified directory does not exist, the program will notify you with an error message.
- If the duration format is incorrect, an appropriate error message will be displayed.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome! Please feel free to submit a pull request or create an issue for suggestions or improvements.

## Acknowledgments

Thank you for using CleanUpTMP. I hope this tool helps you manage your temporary files efficiently!
