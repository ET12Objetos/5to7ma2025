
// Obtener los divs para mostrar los datos
const clientesPresentados = document.getElementById('clientesPresentados');
const clientesJson = document.getElementById('clientesJson');

// Array para guardar los clientes
let clientesArray = [];

// Función para mostrar los clientes presentados
function mostrarClientesPresentados(clientes) {
	if (!clientesPresentados) return;
	clientesPresentados.innerHTML = '';
	clientes.forEach(cliente => {
		const contenedor = document.createElement('div');
		for (const key in cliente) {
			const row = document.createElement('div');
			row.innerHTML = `<strong>${key}</strong>: ${cliente[key]}`;
			contenedor.appendChild(row);
		}
		clientesPresentados.appendChild(contenedor);
	});
}

// Función para mostrar el JSON bruto
function mostrarClientesJson(clientes) {
	if (!clientesJson) return;
	clientesJson.innerHTML = '';
	const pre = document.createElement('pre');
	pre.textContent = JSON.stringify(clientes, null, 2);
	clientesJson.appendChild(pre);
}

// Hacer fetch a la API
fetch('http://localhost:5124/api/clientes')
	.then(response => response.json())
	.then(data => {
		clientesArray = data;
		mostrarClientesPresentados(clientesArray);
		mostrarClientesJson(clientesArray);
	})
	.catch(error => {
		if (clientesPresentados) clientesPresentados.innerHTML = 'Error al obtener los clientes: ' + error;
		if (clientesJson) clientesJson.innerHTML = '';
	});
